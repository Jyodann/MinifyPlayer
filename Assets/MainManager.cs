using Assets;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Assets.ApplicationStates;

public class MainManager : MonoBehaviour
{
    [SerializeField] string DebugAccessQueryString;
    public static MainManager Instance { get; private set; }
    public AuthToken AuthToken;

    #region Managers
    public LoginManager LoginManager;
    public UIManager UIManager;
    #endregion

    #region StateMachine
    private StateMachine<MainManager> ApplicationState;
    public LoginState LoginState;
    public ConnectionErrorState ConnectionErrorState;
    #endregion

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
        LoginManager = GetComponent<LoginManager>();
        UIManager = GetComponent<UIManager>();
        AuthToken = new AuthToken();

        #if UNITY_EDITOR
        if (DebugAccessQueryString != string.Empty)
        {
            AuthToken = new AuthToken(DebugAccessQueryString);
        }
        #endif

        ApplicationState = new StateMachine<MainManager>();  
        LoginState = new LoginState(ApplicationState, this);
        ConnectionErrorState = new ConnectionErrorState(ApplicationState, this);
        ApplicationState.Initialise(LoginState);
    }

    // Update is called once per frame
    void Update()
    {
        ApplicationState.UpdateState();
    }

    public UnityWebRequest GetUnityWebRequestObject(string url, RequestMethods request)
    {
        var webRequest = new UnityWebRequest(url, request.ToString(), new DownloadHandlerBuffer(), null);
        webRequest.SetRequestHeader("Authorization", $"Bearer {AuthToken.access_token}");
        webRequest.SetRequestHeader("Content-Type", "application/json");
        return webRequest;
    }

    public enum RequestMethods
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
                    LoginManager.OpenLoginPrompt();
                    break;
            }
        }
    }

}
