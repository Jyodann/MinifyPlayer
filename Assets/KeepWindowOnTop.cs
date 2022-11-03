using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class KeepWindowOnTop : MonoBehaviour
{
#if !UNITY_STANDALONE_LINUX

    private bool isWindowTop = false;
    // https://stackoverflow.com/a/34703664/5452781
    private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
    static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
    const UInt32 SWP_NOSIZE = 0x0001;
    const UInt32 SWP_NOMOVE = 0x0002;
    const UInt32 SWP_SHOWWINDOW = 0x0040;
    //private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

    // https://forum.unity.com/threads/unity-window-handle.115364/#post-1650240
    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();

    public static IntPtr GetWindowHandle()
    {
        return GetActiveWindow();
    }
#endif

    void Awake()
    {
#if !UNITY_EDITOR && !UNITY_STANDALONE_LINUX
        Debug.Log("Make window stay on top");
        SetWindowPos(GetActiveWindow(), HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
#endif
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isWindowTop)
            {
                SetWindowPos(GetActiveWindow(), HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
            }
            else
            {
                SetWindowPos(GetActiveWindow(), HWND_NOTOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
            }

            isWindowTop = !isWindowTop;
        }
    }
}
