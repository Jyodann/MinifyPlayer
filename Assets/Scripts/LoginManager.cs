using Assets;
using Assets.Scripts;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Net;
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
    private string refreshTokenUrl { get => $"{baseUrl}/refreshtoken"; }

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
        var tokenPayload = JsonConvert.SerializeObject( new TokenPayload()
        {
            redirect_url = redirectUrl,
            code = token,
        } );

        var tokenBytes = System.Text.Encoding.UTF8.GetBytes(tokenPayload);
        

        using (var request = new UnityWebRequest(getTokenUrl, "POST"))
        {
            request.uploadHandler = new UploadHandlerRaw(tokenBytes);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();
            MainManager.Instance.UIManager.SetProceedButtonEnabled(true);
            if (request.result == UnityWebRequest.Result.Success)
            {
                yield break;
            }

            if (request.result == UnityWebRequest.Result.ProtocolError)
            {
                yield break;
            }

            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                yield break;
            }
        }
    }

    // Attempt Authorization with Current Token:
    public void AttemptAuthorization()
    {
        StartCoroutine(VerifyToken());
    }

    public void InformTokenExpiry()
    {
        isAuthorized = false;
        isTokenExpired = true;
    }
    IEnumerator VerifyToken()
    {
        using (var request = MainManager.Instance.GetUnityWebRequestObject("https://api.spotify.com/v1/me/", MainManager.RequestMethods.GET))
        {
            yield return request.SendWebRequest();

            Debug.Log(request.downloadHandler.text);
            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                MainManager.Instance.ApplicationState.ChangeState(MainManager.Instance.ConnectionErrorState);
                yield break;
            }

            if (request.responseCode == 200)
            {
                isAuthorized = true;
                isTokenExpired = false;
                Debug.Log("Managed to verify");
                yield break;
            }

            if (request.responseCode == 401)
            {
                OpenLoginPrompt();
                yield break;
            }
            
        }
    }
}
