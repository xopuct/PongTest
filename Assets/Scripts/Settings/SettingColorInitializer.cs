using UnityEngine;
using System.Collections;

public class SettingColorInitializer : MonoBehaviour
{
    public ConfigColor Colors;

    private void Start()
    {
        foreach (var c in Colors.Colors)
        {
            if (c.Colors.Length == 0)
                continue;
            var setting = Settings.Get(c.Name);
            if (!setting.HasValue())
                setting.SetValue(c.Colors[0]);
        }
    }
}
