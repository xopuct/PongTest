﻿using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
    public BoxCollider2D RacquetCollider;
    bool touched = false;
    int fingerId = -1;

    void Update()
    {
        if (!touched)
        {
            var racquetRect = GetRacquetRect();
            foreach (var pair in InputWrapper.AllInput)
            {
                if (racquetRect.Contains(pair.Value))
                {
                    touched = true;
                    fingerId = pair.Key;
                }
            }
        }
        else
        {
            if (!InputWrapper.AllInput.TryGetValue(fingerId, out var pos))
            {
                touched = false;
                return;
            } 
            var newPosX = Camera.main.ScreenToWorldPoint(pos).x;
            transform.position = new Vector3(newPosX, transform.position.y, transform.position.z);
        }
    }

    Rect GetRacquetRect()
    {
        var min = Camera.main.WorldToScreenPoint(RacquetCollider.bounds.min);
        var max = Camera.main.WorldToScreenPoint(RacquetCollider.bounds.max);
        var screenRect = new Rect(min, max - min);
        return screenRect;
    }
}
