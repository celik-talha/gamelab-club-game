using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PhoneSpawn : MonoBehaviour
{
    private int _randomNumber, _chance;
    [SerializeField] private GameObject phone;
    [SerializeField] private GameObject[] refObjects;
    [SerializeField] private GameObject phoneParent;
    private Vector3 _tempPos;

    private GameObject _created;

    private void SpawnPhone()
    {
        _randomNumber = Random.Range(0, 3);
        _tempPos = refObjects[_randomNumber].transform.position;
        _tempPos.y += 3.7f;
        _created = Instantiate(phone,_tempPos,phone.transform.rotation);
        _created.transform.SetParent(phoneParent.transform);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stand"))
        {
            _chance = Random.Range(1, 15);
            if (_chance < 3)
            {
                SpawnPhone();
            }
        }
    }
}
