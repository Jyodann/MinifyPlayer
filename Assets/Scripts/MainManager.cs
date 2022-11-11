using Assets;
using Assets.ApplicationStates;
using UnityEngine;
using UnityEngine.Networking;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }

    #region Managers

    [HideInInspector] public LoginManager LoginManager;

    [HideInInspector] public UIManager UIManager;

    [HideInInspector] public MarqueeManager MarqueeManager;

    #endregion Managers

    #region StateMachine

    public StateMachine<MainManager> ApplicationState;

    public LoginState LoginState;

    public ConnectionErrorState ConnectionErrorState;

    public MainState MainState;

    public WindowManager WindowManager;

    #endregion StateMachine

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

    private void Start()
    {
        LoginManager = GetComponent<LoginManager>();
        UIManager = GetComponent<UIManager>();
        MarqueeManager = GetComponent<MarqueeManager>();

        ApplicationState = new StateMachine<MainManager>();
        LoginState = new LoginState(ApplicationState, this);
        ConnectionErrorState = new ConnectionErrorState(ApplicationState, this);

        MainState = new MainState(ApplicationState, this);
        ApplicationState.Initialise(LoginState);
    }

    // Update is called once per frame
    private void Update()
    {
        ApplicationState.UpdateState();
    }

    public UnityWebRequest GetUnityWebRequestObject(string url, RequestMethods request)
    {
        var webRequest = new UnityWebRequest(url, request.ToString(), new DownloadHandlerBuffer(), null);
        webRequest.SetRequestHeader("Authorization", $"Bearer {LoginManager.AuthToken.access_token}");
        webRequest.SetRequestHeader("Content-Type", "application/json");
        return webRequest;
    }

    public enum RequestMethods
    {
        GET,

        POST,

        PUT,
    }

    // Tied to PlayPauseButton OnClick()
    public void AttemptPlayPause()
    {
        MainState.AttemptPausePlay();
    }

    // Tied to NextSongButton OnClick()
    public void AttemptPlayNextSong()
    {
        MainState.AttemptSkipSong(true);
    }

    // Tied to PreviousButton OnClick()
    public void AttemptPlayPreviousSong()
    {
        MainState.AttemptSkipSong(false);
    }

    // Tied to Logout Button OnClick()
    public void Logout()
    {
        MainState.Logout();
    }

    public void TogglePinState()
    {
        MainState.PinWindowToTop();
    }

    public void MinimiseWindow()
    {
        MainState.Minimise();
    }

    public void CloseWindow()
    {
        MainState.CloseWindow();
    }

    public void PlayOnSpotify()
    {
        MainState.PlayOnSpotify();
    }
}
