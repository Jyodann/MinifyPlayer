using Assets;
using System.Collections;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Net;

public class MainManager : MonoBehaviour
{
    [SerializeField] string DebugAccessQueryString;
    public static MainManager Instance { get; private set; }
    public AuthToken AuthToken { get; set; }
    public bool isLoggedIn = false;
    private bool attemptingLogin = false;
    private LoginManager loginManager;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        loginManager = GetComponent<LoginManager>();
        AuthToken = new AuthToken();

        #if UNITY_EDITOR
        if (DebugAccessQueryString != string.Empty)
        {
            AuthToken = new AuthToken(DebugAccessQueryString);
        }
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        if (!AuthToken.IsActvated) return;

        if (!attemptingLogin)
        {
            attemptingLogin = true;
            //StartCoroutine(GetCurrentUserProfile());
        }
    }

    private UnityWebRequest GetUnityWebRequestObject(string url, RequestMethods request)
    {
        var webRequest = new UnityWebRequest(url, request.ToString(), new DownloadHandlerBuffer(), null);
        webRequest.SetRequestHeader("Authorization", $"Bearer {AuthToken.access_token}");
        webRequest.SetRequestHeader("Content-Type", "application/json");
        return webRequest;
    }

    internal enum RequestMethods
    {
        GET,
        POST,
        PUT,
    }


    IEnumerator RefreshPlayState()
    {
        using (var webRequest = GetUnityWebRequestObject("https://api.spotify.com/v1/me/player", RequestMethods.GET))
        {
            yield return webRequest.SendWebRequest();
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.Success:
                    var state = JsonConvert.DeserializeObject<PlaybackState>(webRequest.downloadHandler.text);
                    break;
                case UnityWebRequest.Result.ConnectionError:
                    Debug.LogError("Connection Error");
                    break;

                default:
                    loginManager.OpenLoginPrompt();
                    break;
            }
        }
    }

    
}
