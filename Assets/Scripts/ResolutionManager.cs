using UnityEngine;

public class ResolutionManager : MonoBehaviour
{
    private void Start()
    {
        Screen.SetResolution(300, 350, false);
    }
}
