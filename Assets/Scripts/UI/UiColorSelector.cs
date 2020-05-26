using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class UiColorSelector : MonoBehaviour
{
    public ConfigColor Colors;
    public string Property;
    public UiColorContainer Prototype;

    List<GameObject> instances = new List<GameObject>();
    Color[] colors;

    private void Start() => Prototype.gameObject.SetActive(false);

    private void OnEnable()
    {
        MaybeInitColors();
        UpdateData();
    }

    void UpdateData()
    {
        foreach (var i in instances)
            Destroy(i);
        Color selectedColor = GetSelectedColor();

        foreach (var c in colors)
        {
            var inst = Instantiate(Prototype, transform);
            inst.gameObject.SetActive(true);
            instances.Add(inst.gameObject);
            inst.SetData(c, OnSelectColor);
            if (inst.Data == selectedColor)
                inst.Select();
        }
    }

    private Color GetSelectedColor()
    {
        var setting = Settings.Get(Property);
        if (setting.HasValue())
            return JsonUtility.FromJson<Color>(PlayerPrefs.GetString(Property));
        return colors.Length > 0 ? colors[0] : Color.white;
    }

    void OnSelectColor(Color color) => Settings.Get(Property).SetValue(color);

    private void MaybeInitColors()
    {
        colors = Colors.Get(Property);
        if (colors == null)
            colors = new[] { Color.white };
    }
}
