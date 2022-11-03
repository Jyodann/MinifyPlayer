using Assets;
using Assets.Scripts;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Net;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Networking;

public class LoginManager : MonoBehaviour
{
    [SerializeField] string DebugString;
    
    public AuthToken AuthToken;
    public bool isAuthorized { get; private set; }
    public bool isTokenExpired = false;

    
    private string baseUrl = string.Empty;
    private string redirectUrl { get => $"{baseUrl}/callback"; }
    private string getTokenUrl { get => $"{baseUrl}/getToken"; }
    private string refreshTokenUrl { get => $"{baseUrl}/refresh_token"; }

    public string client_id = "9830ce611cad40ab98aaca36e75c0b79";
    
    void Start()
    {
        // Start with Empty Auth Token:
        AuthToken = new AuthToken();
#if UNITY_EDITOR
        // Editing
        baseUrl = "https://localhost:7252";
#else 
        // Production URL:
        baseUrl = "https://localhost:7252";
#endif
    }

    // Opens the GET Request for Callback to Application:
    public void OpenLoginPrompt()
    {
        Application.OpenURL($"https://accounts.spotify.com/authorize?client_id={client_id}&response_type=code&redirect_uri={redirectUrl}&scope=user-read-playback-state user-modify-playback-state user-read-currently-playing user-read-playback-position");
    }

    public void GetToken()
    {
        var token = MainManager.Instance.UIManager.TokenInput;

        StartCoroutine(GetTokenFromSpotify(token));
    }

    IEnumerator GetTokenFromSpotify(string token)
    {
        MainManager.Instance.UIManager.SetProceedButtonEnabled(false);

        using (var request = UnityWebRequest.Get($"{getTokenUrl}?code={token}&redirect_url={redirectUrl}"))
        {
            yield return request.SendWebRequest();

            print($"{getTokenUrl}?code={token}&redirect_url={redirectUrl}");
            print(request.downloadHandler.text);
            MainManager.Instance.UIManager.SetProceedButtonEnabled(true);

            if (request.result == UnityWebRequest.Result.Success)
            {
                var authToken = JsonConvert.DeserializeObject<AuthToken>(request.downloadHandler.text);

                if (authToken.access_token == null)
                {
                    Debug.LogError("Access Token invalid");
                    yield break;
                }

                MainManager.Instance.LoginManager.AuthToken = authToken;

                MainManager.Instance.ApplicationState.ChangeState(MainManager.Instance.MainState);

                print(authToken);
                yield break;
            }

            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                //Handle if no internet connection
                yield break;
            }
        }
    }

    public void RefreshToken()
    {
        StartCoroutine(GetRefreshToken(AuthToken.refresh_token));
    }

    IEnumerator GetRefreshToken(string token)
    {
        using (var request = UnityWebRequest.Get($"{refreshTokenUrl}?refresh_token={token}"))
        {
            yield return request.SendWebRequest();
            print(request.downloadHandler.text);
            if (request.result == UnityWebRequest.Result.Success)
            {
                var authToken = JsonConvert.DeserializeObject<AuthToken>(request.downloadHandler.text);

                if (authToken.access_token == null)
                {
                    Debug.LogError("Access Token invalid");
                    yield break;
                }

                print(authToken);

                MainManager.Instance.LoginManager.AuthToken.access_token = authToken.access_token;
                yield break;
            }

            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                //Handle if no internet connection
                yield break;
            }
        }
    }
}
