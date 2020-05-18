using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount>0)
            Debug.Log("You touch my talala");

        foreach (var t in Input.touches)
        {
            Debug.Log(t.fingerId);
            Debug.Log(t.position);
        }
    }
}
