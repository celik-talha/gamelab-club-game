using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ItemSpin : MonoBehaviour
{
    void Start()
    {
    }

    private void FixedUpdate()
    {
        transform.Rotate(1.5f,0f,0f,Space.Self);
    }
}
