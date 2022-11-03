using Assets;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class LoginManager : MonoBehaviour
{
    [SerializeField] string DebugString;

    public AuthToken AuthToken;
    public bool isAuthorized { get; private set; }
    public bool isTokenExpired = false;
    private string redirect_url; 
    public string client_id = "9830ce611cad40ab98aaca36e75c0b79";
    
    void Start()
    {
        // Start with Empty Auth Token:
        AuthToken = new AuthToken();
#if UNITY_EDITOR
        redirect_url = "https://localhost:7252/callback";

        if (DebugString != string.Empty)
        {
            AuthToken = new AuthToken(DebugString);
            AttemptAuthorization();
        }
#else 
        redirect_url = "minify://";
#endif
    }

    private void Update()
    {

    }

    // Opens the GET Request for Callback to Application:
    public void OpenLoginPrompt()
    {
        Application.OpenURL($"https://accounts.spotify.com/authorize?client_id={client_id}&response_type=code&redirect_uri={redirect_url}&scope=user-read-playback-state user-modify-playback-state user-read-currently-playing user-read-playback-position");
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
