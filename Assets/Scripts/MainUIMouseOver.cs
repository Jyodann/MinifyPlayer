using Assets.Managers;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainUIMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        MainManager.Instance.MainState.EnablePlayPauseOverlay(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        MainManager.Instance.MainState.EnablePlayPauseOverlay(false);
    }
}
