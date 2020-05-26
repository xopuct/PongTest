using UnityEngine;
using System.Collections;
using System;

public class PauseController : MonoBehaviour
{
    public UiScreens ScreenManager;
    void Start()
    {
        ScreenManager.OnScreenChanged += OnScreenTypeChanged;
        OnScreenTypeChanged(ScreenManager.ScreenType);
    }

    void OnDestroy() => ScreenManager.OnScreenChanged -= OnScreenTypeChanged;

    void OnScreenTypeChanged(UiScreenType newScreen) => Game.IsPaused = newScreen != UiScreenType.Hud;
}
