using UnityEngine;
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
            foreach (var t in Input.touches)
            {
                if (racquetRect.Contains(t.position))
                {
                    touched = true;
                    fingerId = t.fingerId;
                }
            }
        }
        else
        {
            var touchIndex = GetTouchIndex(fingerId);
            if (touchIndex == -1)
            {
                touched = false;
                return;
            }
            var touchPos = Input.touches[touchIndex].position;
            var newPosX = Camera.main.ScreenToWorldPoint(touchPos).x;
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

    int GetTouchIndex(int fingerId)
    {
        for (int i = 0; i < Input.touches.Length; i++)
        {
            Touch t = Input.touches[i];
            if (t.fingerId == fingerId)
                return i;
        }
        return -1;
    }
}
