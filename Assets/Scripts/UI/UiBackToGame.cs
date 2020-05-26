using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class UiBackToGame : MonoBehaviour
{
    public Button BackButton;
    public UiScreens ScreenManager;

    private void Start() => BackButton.onClick.AddListener(OnBack);

    private void OnBack() => ScreenManager.OpenScreen(UiScreenType.Hud);
}
