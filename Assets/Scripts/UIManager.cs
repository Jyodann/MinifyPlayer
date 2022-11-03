using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI SongNameText;
    [SerializeField] RawImage SongAlbumArt;
    [SerializeField] TMP_InputField TokenInputUI;
    [SerializeField] Button ProceedButton;
    
    [SerializeField] GameObject[] UIs;

    public string TokenInput { get => TokenInputUI.text; }


    public enum UI 
    {
        Login,
        Main,
        ConnectionError
    }

    public void ShowUI(UI selectedUI)
    {
        string uiString;
        switch (selectedUI)
        {
            case UI.Login:
                uiString = "LoginUI";
                break;
            case UI.Main:
                uiString = "MainUI";
                break;
            case UI.ConnectionError:
                uiString = "NetworkUnreachableUI";
                break;
            default:
                uiString = "None";
                break;
        }

        ShowUI(uiString);
    }

    private void ShowUI(string name)
    {
        GameObject selectedUI = null;
        foreach (var item in UIs)
        {
            if (item.name == name) selectedUI = item;
            item.SetActive(false);
        }
        if (selectedUI == null) {
            Debug.LogError($"UI of {name} not found");
            return;
        }
        selectedUI.SetActive(true);
    }

    public void SetSongName(string name) => SongNameText.text = name;

    public void SetAlbumArtURL(string url)
    {
        StartCoroutine(GetRemoteTexture(url));
    }

    public void SetProceedButtonEnabled(bool isEnabled) => ProceedButton.interactable = isEnabled;

    IEnumerator GetRemoteTexture(string uri)
    {
        using (var request = UnityWebRequestTexture.GetTexture(uri))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                SongAlbumArt.texture = DownloadHandlerTexture.GetContent(request);
            }
        }
    }
}
