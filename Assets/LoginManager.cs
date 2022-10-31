using UnityEngine;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{    
    private string redirect_url; 
    public string client_id = "9830ce611cad40ab98aaca36e75c0b79";
    
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        redirect_url = "http://localhost:8000/callback";
#else 
        redirect_url = "minify://";
#endif
    }

    public void OpenLoginPrompt()
    {
        Application.OpenURL($"https://accounts.spotify.com/authorize?client_id={client_id}&response_type=token&redirect_uri={redirect_url}&scope=user-read-playback-state user-modify-playback-state user-read-currently-playing user-read-playback-position");
    }

    
}
