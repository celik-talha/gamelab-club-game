using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreFinish : MonoBehaviour
{
    private GameScript _gameScript;
    void Start()
    {
        _gameScript = GameObject.FindWithTag("Game").GetComponent<GameScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _gameScript.preFinish();
    }
}
