using Assets;
using System.Collections;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
public class MainManager : MonoBehaviour
{
    [SerializeField] string DebugAccessQueryString;

    public static MainManager Instance { get; private set; }

    public AuthToken AuthToken { get; set; }

    public bool isLoggedIn = false;

    private bool attemptingLogin = false;

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
    // Start is called before the first frame update
    void Start()
    {
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
            StartCoroutine(LoginToSpotify());
        }
        
        
    }

    IEnumerator LoginToSpotify()
    {
        using (var webRequest = UnityWebRequest.Get("https://api.spotify.com/v1/me/player"))
        {
            webRequest.SetRequestHeader("Authorization", $"Bearer {AuthToken.access_token}");
            webRequest.SetRequestHeader("Content-Type", "application/json");

            yield return webRequest.SendWebRequest();
            print(webRequest.downloadHandler.text);
            print(webRequest.result);
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.InProgress:
                    break;
                case UnityWebRequest.Result.Success:
                    var state = JsonConvert.DeserializeObject<PlaybackState>(webRequest.downloadHandler.text);
                    print(state.item.name);
                    break;
                case UnityWebRequest.Result.ConnectionError:
                    Debug.LogError("Connection Error");
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    break;
                case UnityWebRequest.Result.DataProcessingError:
                    break;
                default:
                    break;
            }
        }
    }
}
