using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneScript : MonoBehaviour
{
    private GameObject _gameObject;
    private GameScript _gameScript;
    void Start()
    {
        _gameObject = GameObject.FindWithTag("Game").gameObject;
        _gameScript = _gameObject.GetComponent<GameScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _gameScript.getPhone();
        Destroy(this.transform.parent.gameObject);
    }
}
