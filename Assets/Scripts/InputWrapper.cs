using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class InputWrapper : MonoBehaviour
{
    const int MouseDeviceId = 100000;
    public static Dictionary<int, Vector2> AllInput = new Dictionary<int, Vector2>();

    void Update()
    {
        AllInput.Clear();
        if (Input.GetMouseButton(0))
            AllInput.Add(MouseDeviceId, Input.mousePosition);
        foreach (var t in Input.touches)
        {
            AllInput.Add(t.fingerId, t.position);
        }
    }
}