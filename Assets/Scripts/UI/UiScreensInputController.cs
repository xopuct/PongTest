using UnityEngine;
using System.Collections;

public class UiScreensInputController : MonoBehaviour
{
    public UiScreens ScreenManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ScreenManager.ScreenType == UiScreenType.Options)
                ScreenManager.OpenScreen(UiScreenType.Hud);
            if (ScreenManager.ScreenType == UiScreenType.Hud)
                ScreenManager.OpenScreen(UiScreenType.Options);
        }
    }
}
