using UnityEngine;
using System.Collections;
using System;

public enum UiScreenType
{
    Hud,
    Options
}

public class UiScreens : MonoBehaviour
{
    public event Action<UiScreenType> OnScreenChanged;
    public UiScreenType ScreenType { get; protected set; }

    public GameObject HudScreen;
    public GameObject OptionsScreen;


    public void OpenScreen(UiScreenType newScreenType)
    {
        ScreenType = newScreenType;
        HudScreen.SetActive(newScreenType == UiScreenType.Hud);
        OptionsScreen.SetActive(newScreenType == UiScreenType.Options);
        OnScreenChanged?.Invoke(ScreenType);
    }
}
