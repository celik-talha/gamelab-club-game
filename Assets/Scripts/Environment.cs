using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    private Vector3 _move;
    private Vector3 _pos;
    private Vector3 _default;

    public bool isPlaneLive;

    private Transform _transform;
    
    void Start()
    {
        _default = new Vector3(0, 0, -1f);
        _move = _default;
        _transform = this.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isPlaneLive)
        {
            _pos = this.transform.position;
            _transform.position = _pos + (_move);
        }
    }
    

    public void SetSpeed(float i)
    {
        _move = _default * i;
    }
}
