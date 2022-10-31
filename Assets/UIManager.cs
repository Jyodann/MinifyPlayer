using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject[] UIs;
    public enum UI 
    {
        Login,
        Main,
        ConnectionError
    }

    private void Start()
    {
        foreach (var UI in UIs)
        {
            UI.SetActive(false);
        }
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
}
