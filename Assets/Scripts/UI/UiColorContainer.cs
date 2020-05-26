using System;
using UnityEngine;
using UnityEngine.UI;

public class UiColorContainer : MonoBehaviour
{
    public Image ColorContainer;
    public Toggle Toggle;
    Action<Color> callback;

    public Color Data => ColorContainer.color;

    private void Awake() => Toggle.onValueChanged.AddListener(OnValueChanged);

    private void OnValueChanged(bool value)
    {
        if (value)
            callback?.Invoke(Data);
    }

    public void SetData(Color color, Action<Color> onSelect)
    {
        ColorContainer.color = color;
        callback = onSelect;
    }

    public void Select() => Toggle.isOn = true;
}