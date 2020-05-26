using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ConfigColor", menuName = "ScriptableObjects/ConfigColor", order = 1)]
public class ConfigColor : ScriptableObject
{
    [Serializable]
    public struct ColorPair
    {
        public string Name;
        public Color[] Colors;
    }
    public ColorPair[] Colors;

    public Color[] Get(string name)
    {
        var results = Array.FindAll(Colors, c => c.Name == name);
        if (results.Length > 0)
            return results[0].Colors;
        return null;
    }
}
