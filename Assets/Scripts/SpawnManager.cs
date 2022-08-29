using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    private int _randomNumber,_chance,_second,_stand;
    [SerializeField] private GameObject[] stands;
    [SerializeField] private GameObject refObject0;
    [SerializeField] private GameObject refObject1; 
    [SerializeField] private GameObject refObject2;
    private Vector3[] _pos = new Vector3[3];

    [SerializeField] private GameObject standsParent;
    private GameObject _temp;

    [SerializeField] private GameObject managerObject;
    private GameScript _gameScript;
    private int _status = 1;

    private float _timer = 0f;

    private int _lastPos1;
    private int _lastPos2;

    public bool letSpawn = true;
    
    void Start()
    {
        _pos[0] = refObject0.transform.position;
        _pos[1] = refObject1.transform.position;
        _pos[2] = refObject2.transform.position;

        _gameScript = managerObject.GetComponent<GameScript>();
        
        Random.seed = System.DateTime.Now.Millisecond;
    }

    private void FixedUpdate()
    {
        _timer += (1 * Time.deltaTime);
    }

    public void SpawnStand()
    {
        if (_timer > 0.4f && letSpawn)
        {
            _timer = 0f;
            _randomNumber = Random.Range(0, 3);
            _chance = Random.Range(1, 3);
            
            SpawnAt(_randomNumber);
        
            if (_randomNumber == 0)
            {
                if (_chance == 1)
                {
                    _second = Random.Range(1, 3);
                    if (_second == 1 && ( (_lastPos1 != 1 || _lastPos2 != 2) ^ (_lastPos1 != 2 || _lastPos2 !=1) ))
                    {
                        SpawnAt(_second);
                    }
                    else if (_second == 2)
                    {
                        SpawnAt(_second);
                    }
                }
            }
            else if (_randomNumber == 1)
            {
                if (_chance == 1)
                {
                    _second = Random.Range(0, 2);
                    if (_second == 1 && ( (_lastPos1 != 0 || _lastPos2 != 1) ^ (_lastPos1 != 1 || _lastPos2 !=0) ))
                    {
                        _second++;
                        SpawnAt(_second);
                    }
                    else if (( (_lastPos1 != 1 || _lastPos2 != 2) ^ (_lastPos1 != 2 || _lastPos2 !=1) ))
                    {
                        SpawnAt(_second);
                    }
                }
            }
            else
            {
                if (_chance == 1)
                {
                    _second = Random.Range(0, 2);
                    if (_second == 1 && ( (_lastPos1 != 0 || _lastPos2 != 1) ^ (_lastPos1 != 1 || _lastPos2 !=0) ))
                    {
                        SpawnAt(_second);
                    }
                    else if (_second == 0)
                    {
                        SpawnAt(_second);
                    }
                }
            }

            _lastPos1 = _randomNumber;
            if (_chance == 0)
            {
                _lastPos2 = -1;
            }
            else
            {
                _lastPos2 = _second;
            }
        }
    }

    private void SpawnAt(int no)
    {
        _stand = Random.Range(0, 6);
        _status = _gameScript.status;
        
        _temp = Instantiate(stands[_stand],_pos[no],refObject0.transform.rotation);
        _temp.transform.SetParent(standsParent.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stand"))
        {
            //Destroy(other.transform.parent.gameObject);
            SpawnStand();
        }
    }
}
