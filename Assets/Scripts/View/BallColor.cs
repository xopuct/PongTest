using UnityEngine;
using System.Collections;

public class BallColor : MonoBehaviour
{
    public SpriteRenderer Renderer;
    const string BallColorSettingName = "BallColor";

    private void Start()
    {
        Settings.Get(BallColorSettingName).SettingChanged += OnColorChanged;
        UpdateColor();
    }

    private void OnDestroy() => Settings.Get(BallColorSettingName).SettingChanged -= OnColorChanged;

    private void OnColorChanged() => UpdateColor();

    void UpdateColor()
    {
        var setting = Settings.Get(BallColorSettingName);
        if (setting.HasValue())
            Renderer.color = setting.GetValue<Color>();
}
}
