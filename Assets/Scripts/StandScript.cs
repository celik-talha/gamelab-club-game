using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandScript : MonoBehaviour
{
    private GameObject _controlObject;
    private GameScript _gameScript;
    private GameObject _parent;
    void Start()
    {
        _controlObject = GameObject.FindWithTag("Game").gameObject;
        _gameScript = _controlObject.GetComponent<GameScript>();
        _parent = this.transform.parent.gameObject;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHit"))
        {
            _gameScript.Hit();
            foreach (MeshRenderer meshRenderer in _parent.transform.GetComponentsInChildren<MeshRenderer>())
            {
                meshRenderer.enabled = false;
            }

            Destroy(_parent.transform.Find("Idle_2").gameObject);
        }
    }
}
