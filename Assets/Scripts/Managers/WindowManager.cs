using UnityEngine;

namespace Assets.Managers
{
    public class WindowManager : MonoBehaviour
    {
        private readonly string PINNED_PLAYERPREF = "pinned_state";

        private KeepWindowOnTop KeepWindowOnTop;

        private WindowScript WindowScript;

        // Start is called before the first frame update
        private void Start()
        {
            KeepWindowOnTop = GetComponent<KeepWindowOnTop>();
            WindowScript = GetComponent<WindowScript>();

#if !UNITY_EDITOR && UNITY_STANDALONE_WIN
            WindowScript.OnNoBorderBtnClick();
#endif
        }

        public void PinWindowToTop(bool isPinned)
        {
            KeepWindowOnTop.PinWindow(isPinned);
        }

        public void SavePinnedState(bool isPinned)
        {
            PlayerPrefs.SetString(PINNED_PLAYERPREF, isPinned.ToString());
        }

        public bool LoadPinnedState()
        {
            return bool.Parse(PlayerPrefs.GetString(PINNED_PLAYERPREF, false.ToString()));
        }

        public void MinimiseWindow()
        {
            WindowScript.OnMinimizeBtnClick();
        }
    }
}