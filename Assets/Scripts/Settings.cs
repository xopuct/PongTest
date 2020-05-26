using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Setting
{
    public event Action SettingChanged;
    public string SettingName;
    object value;
    public T GetValue<T>()
    {
        if (value == null)
            value = JsonUtility.FromJson<T>(PlayerPrefs.GetString(SettingName));
        return (T)value;
    }

    public void SetValue(object value)
    {
        this.value = value;
        PlayerPrefs.SetString(SettingName, JsonUtility.ToJson(value));
        SettingChanged?.Invoke();
    }

    public bool HasValue() => value != null || PlayerPrefs.HasKey(SettingName);
}

public static class Settings
{
    static Dictionary<string, Setting> settings = new Dictionary<string, Setting>();

    public static Setting Get(string name)
    {
        if (!settings.TryGetValue(name, out var setting))
        {
            setting = new Setting() { SettingName = name };
            settings.Add(name, setting);
        }
        return setting;
    }
}
