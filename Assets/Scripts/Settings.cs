using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public GameScript _GameScript;
    
    void Start()
    {
        _GameScript = GameObject.FindWithTag("Game").GetComponent<GameScript>();
    }

    public void buttonClick()
    {
        _GameScript.buttonClick();
        _GameScript.OpenSettings();
    }
}
