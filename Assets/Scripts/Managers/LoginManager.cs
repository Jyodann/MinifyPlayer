using Assets.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Managers
{
    public class LoginManager : MonoBehaviour
    {
        private AuthToken authToken = new();

        public bool isAuthorized { get; private set; }

        public bool isTokenExpired = false;

        private string baseUrl = string.Empty;

        private string RedirectUrl { get => $"{baseUrl}/callback"; }

        private string GetTokenUrl { get => $"{baseUrl}/gettoken"; }

        private string refreshTokenUrl { get => $"{baseUrl}/refreshtoken"; }

        internal AuthToken AuthToken { get => authToken; set => authToken = value; }

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
            Application.OpenURL(Uri.EscapeUriString($"https://accounts.spotify.com/authorize?client_id={client_id}&response_type=code&redirect_uri={RedirectUrl}&scope=user-modify-playback-state user-read-currently-playing"));
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

            using var request = UnityWebRequest.Get($"{GetTokenUrl}?code={token}&redirect_url={RedirectUrl}");
            yield return request.SendWebRequest();

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
                MainManager.Instance.UIManager.EmptyMinifyCodeText();
                MainManager.Instance.ApplicationState.ChangeState(MainManager.Instance.MainState);
                yield break;
            }
            MainManager.Instance.UIManager.SetLoginErrorText("No Internet Connection.\nPlease try again.");
        }

        public void RefreshToken(bool refreshLogin)
        {
            StartCoroutine(GetRefreshToken(AuthToken.refresh_token, refreshLogin));
        }

        private IEnumerator GetRefreshToken(string token, bool refreshLogin)
        {
            using var request = UnityWebRequest.Get($"{refreshTokenUrl}?refresh_token={token}");
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                var authToken = JsonConvert.DeserializeObject<AuthToken>(request.downloadHandler.text);

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
}
