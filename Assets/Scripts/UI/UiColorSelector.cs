using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class UiColorSelector : MonoBehaviour
{
    public Color[] Colors;
    public string Property;
    public UiColorContainer Prototype;

    List<GameObject> instances = new List<GameObject>();

    private void Start()
    {
        Prototype.gameObject.SetActive(false); 
    }

    private void OnEnable() => UpdateData();

    void UpdateData()
    {
        foreach (var i in instances)
            Destroy(i);
        Color selectedColor = Colors.Length > 0 ? Colors[0] : Color.white;
        var setting = Settings.Get(Property);
        if (setting.HasValue())
            selectedColor = JsonUtility.FromJson<Color>(PlayerPrefs.GetString(Property));

        foreach (var c in Colors)
        {
            var inst = Instantiate(Prototype, transform);
            inst.gameObject.SetActive(true);
            instances.Add(inst.gameObject);
            inst.SetData(c, OnSelectColor);
            if (inst.Data == selectedColor)
                inst.Select();
        }
    }

    void OnSelectColor(Color color) => Settings.Get(Property).SetValue(color);
}
