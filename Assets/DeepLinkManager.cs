using Assets;
using UnityEngine;

public class DeepLinkManager : MonoBehaviour
{
    /// <summary>
    /// This class handles the capturing of Client_ID from the deeplink
    /// minify://
    /// </summary>
    public static DeepLinkManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Application.deepLinkActivated += OnDeepLinkActivated;
            if (!string.IsNullOrEmpty(Application.absoluteURL))
            {
                // Cold start and Application.absoluteURL not null so process Deep Link.
                OnDeepLinkActivated(Application.absoluteURL);
            }
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDeepLinkActivated(string url)
    {
        MainManager.Instance.AuthToken = new AuthToken(url);
    }
}
