using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class InputController : MonoBehaviour
{
    private Vector2 _firstPos;
    private bool _letMove = false;
    private bool _moveRight = false;
    private bool _moveLeft = false;
    private int _slideCount = 0;
    private bool _onAnimation = false;
    private Rigidbody _playerRb;
    private Transform _playerTransform;
    private int _way = 2;

    [SerializeField] private GameObject _GameController;
    private GameScript _gameScript;

    private bool _started = false;
    void Start()
    {
        _playerRb = gameObject.GetComponent<Rigidbody>();
        _playerTransform = gameObject.GetComponent<Transform>();
        _gameScript = _GameController.GetComponent<GameScript>();
    }
    
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch firstTouch = Input.GetTouch(0);
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                _firstPos = firstTouch.position;
                if (!_onAnimation)
                {
                    _letMove = true;
                }
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Moved && _letMove)
            {
                if (firstTouch.position.x > _firstPos.x + 200f && _way != 3)
                {
                    _onAnimation = true;
                    _moveRight = true;
                    _firstPos = firstTouch.position;
                    _letMove = false;
                    _way++;
                }
                
                else if (firstTouch.position.x < _firstPos.x - 200f && _way != 1)
                {
                    _onAnimation = true;
                    _moveLeft = true;
                    _firstPos = firstTouch.position;
                    _letMove = false;
                    _way--;
                }
                
                else if (firstTouch.position.y > _firstPos.y + 300f)
                {
                    _playerRb.AddForce(Vector3.up * 500f);
                    _firstPos = firstTouch.position;
                    _letMove = false;
                }
            }
            
        }

        if (Input.GetButtonDown("Fire1") && _started == false && _gameScript._time > 0.1f)
        {
            Touch _touch = Input.GetTouch(0);
            if (_touch.position.y > Screen.height/7f)
            {
                _gameScript.StartGame();
                _started = true;
            }
            
        }
        
    }

    private void FixedUpdate()
    {
        if (_moveRight)
        {
            Vector3 thisPos = _playerTransform.position;
            thisPos.x = thisPos.x + 0.8f;
            _playerTransform.position = thisPos;
            _slideCount++;
            
            if (_slideCount > 7)
            {
                _moveRight = false;
                _slideCount = 0;
                _onAnimation = false;
            }
        }
        else if (_moveLeft)
        {
            Vector3 thisPos = _playerTransform.transform.position;
            thisPos.x = thisPos.x - 0.8f;
            _playerTransform.position = thisPos;
            _slideCount++;
            
            if (_slideCount > 7)
            {
                _moveLeft = false;
                _slideCount = 0;
                _onAnimation = false;
            }
        }
    }
}
