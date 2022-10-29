using Assets;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    [SerializeField] string DebugAccessQueryString;

    public static MainManager Instance { get; private set; }

    public AuthToken AuthToken { get; set; }

    

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
        if (AuthToken.IsActvated)
        {
            Debug.Log($"User Logged in! {AuthToken}");
        }
    }
}
