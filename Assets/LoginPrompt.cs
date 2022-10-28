using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginPrompt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenLoginPrompt()
    {
        Application.OpenURL("https://accounts.spotify.com/authorize?client_id=9830ce611cad40ab98aaca36e75c0b79&response_type=token&redirect_uri=minify://&scope=user-read-playback-state user-modify-playback-state user-read-currently-playing user-read-playback-position");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
