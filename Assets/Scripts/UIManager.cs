using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI SongNameText;

    [SerializeField] private RawImage SongAlbumArt;

    [SerializeField] private TMP_InputField TokenInputUI;

    [SerializeField] private Button ProceedButton;

    [SerializeField] private GameObject[] UIs;

    [SerializeField] private GameObject PlayPauseOverlay;

    [SerializeField] private Button PlayPauseButton;

    [SerializeField] private Sprite PlayingSprite, PauseSprite;

    [SerializeField] private Texture2D MusicOn, MusicOff, Search;

    private Image PlayPauseOverlayImage;

    public string TokenInput { get => TokenInputUI.text; }

    private void Start()
    {
        PlayPauseOverlayImage = PlayPauseOverlay.GetComponent<Image>();
    }

    public enum UI
    {
        Login,

        Main,

        ConnectionError
    }

    public enum AlbumArtIcons
    {
        MusicOn,

        MusicOff,

        Search
    }

    private Texture2D GetAlbumArtIcon(AlbumArtIcons icons)
    {
        switch (icons)
        {
            case AlbumArtIcons.MusicOn:
                return MusicOn;

            case AlbumArtIcons.MusicOff:
                return MusicOff;

            case AlbumArtIcons.Search:
                return Search;
        }

        return null;
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
        if (selectedUI == null)
        {
            Debug.LogError($"UI of {name} not found");
            return;
        }
        selectedUI.SetActive(true);
    }

    public void SetSongName(string name)
    {
        SongNameText.text = name;
        MainManager.Instance.MarqueeManager.isNewSong = true;
    }

    public void SetAlbumArt(string url)
    {
        StartCoroutine(GetRemoteTexture(url));
    }

    public void SetAlbumArt(AlbumArtIcons icon)
    {
        SongAlbumArt.texture = GetAlbumArtIcon(icon);
    }

    public void SetProceedButtonEnabled(bool isEnabled) => ProceedButton.interactable = isEnabled;

    private IEnumerator GetRemoteTexture(string uri)
    {
        Debug.Log("UIManager Downloaded New Textures");
        using (var request = UnityWebRequestTexture.GetTexture(uri))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                SongAlbumArt.texture = DownloadHandlerTexture.GetContent(request);
            }
        }
    }

    public void EnablePlayPauseOverlay(bool isEnabled)
    {
        if (isEnabled)
        {
            PlayPauseOverlayImage.DOFade(0.8f, .2f);
            PlayPauseButton.image.DOFade(1, .2f);
            PlayPauseOverlay.SetActive(isEnabled);
            return;
        }
        PlayPauseOverlayImage.DOFade(0f, .2f).OnComplete(() =>
        {
            PlayPauseOverlay.SetActive(isEnabled);
        });
        PlayPauseButton.image.DOFade(0f, .2f);
    }

    public void SetPlayPauseButtonState(bool isPlaying)
    {
        PlayPauseButton.image.sprite = isPlaying ? PauseSprite : PlayingSprite;
    }
}
