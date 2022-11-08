using Assets;
using Newtonsoft.Json;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class LoginManager : MonoBehaviour
{
    public AuthToken AuthToken = new AuthToken();

    public bool isAuthorized { get; private set; }

    public bool isTokenExpired = false;

    private string baseUrl = string.Empty;

    private string redirectUrl { get => $"{baseUrl}/callback"; }

    private string getTokenUrl { get => $"{baseUrl}/gettoken"; }

    private string refreshTokenUrl { get => $"{baseUrl}/refreshtoken"; }

    public string client_id = "9830ce611cad40ab98aaca36e75c0b79";

    private void Awake()
    {
        // Start with Empty Auth Token:
#if UNITY_EDITOR
        baseUrl = "https://localhost:7252";
#else
        baseUrl = "https://r59741kpgh.execute-api.ap-southeast-1.amazonaws.com/prod";
#endif
    }

    // Opens the GET Request for Callback to Application:
    public void OpenLoginPrompt()
    {
        Application.OpenURL($"https://accounts.spotify.com/authorize?client_id={client_id}&response_type=code&redirect_uri={redirectUrl}&scope=user-read-playback-state user-modify-playback-state user-read-currently-playing");
    }

    public void GetToken()
    {
        var token = MainManager.Instance.UIManager.TokenInput;
        MainManager.Instance.UIManager.SetLoginErrorText(string.Empty);
        StartCoroutine(GetTokenFromSpotify(token));
    }

    private IEnumerator GetTokenFromSpotify(string token)
    {
        MainManager.Instance.UIManager.SetProceedButtonEnabled(false);

        using (var request = UnityWebRequest.Get($"{getTokenUrl}?code={token}&redirect_url={redirectUrl}"))
        {
            yield return request.SendWebRequest();

            print($"{getTokenUrl}?code={token}&redirect_url={redirectUrl}");
            print(request.result.ToString());
            MainManager.Instance.UIManager.SetProceedButtonEnabled(true);

            if (request.result == UnityWebRequest.Result.Success)
            {
                var authToken = JsonConvert.DeserializeObject<AuthToken>(request.downloadHandler.text);
                print(request.downloadHandler.text);
                if (authToken.access_token == null)
                {
                    Debug.LogError("Access Token invalid");
                    MainManager.Instance.UIManager.SetLoginErrorText("Unable to verify code. Please try to login again.");
                    yield break;
                }

                MainManager.Instance.LoginManager.AuthToken = authToken;
                PlayerPrefs.SetString("refresh_token", authToken.refresh_token);
                MainManager.Instance.ApplicationState.ChangeState(MainManager.Instance.MainState);
                yield break;
            }
            MainManager.Instance.UIManager.SetLoginErrorText("No Internet Connection.\nPlease try again.");
        }
    }

    public void RefreshToken(bool refreshLogin)
    {
        StartCoroutine(GetRefreshToken(AuthToken.refresh_token, refreshLogin));
    }

    private IEnumerator GetRefreshToken(string token, bool refreshLogin)
    {
        print($"RefreshToken: {token}");
        using (var request = UnityWebRequest.Get($"{refreshTokenUrl}?refresh_token={token}"))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                var authToken = JsonConvert.DeserializeObject<AuthToken>(request.downloadHandler.text);
                print(request.downloadHandler.text);
                if (authToken.access_token == null)
                {
                    Debug.LogError("Access Token invalid");
                    MainManager.Instance.UIManager.SetLoginErrorText("Login Expired.\nPlease login again");
                    yield break;
                }

                MainManager.Instance.LoginManager.AuthToken.access_token = authToken.access_token;

                if (refreshLogin)
                {
                    MainManager.Instance.ApplicationState.ChangeState(MainManager.Instance.MainState);
                }
                yield break;
            }

            MainManager.Instance.UIManager.SetLoginErrorText("No Internet Connection.\nPlease try again.");
        }
    }

    public void SetRefreshToken(string token) => AuthToken.refresh_token = token;

    public void InValidateToken()
    {
        AuthToken.refresh_token = string.Empty;
        PlayerPrefs.SetString("refresh_token", string.Empty);
    }

    public bool GetRefreshTokenFromMemory(out string refreshToken)
    {
        refreshToken = PlayerPrefs.GetString("refresh_token", string.Empty);

        return refreshToken != string.Empty;
    }
}
