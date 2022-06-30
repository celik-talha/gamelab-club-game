using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    private Vector3 _move;
    private Vector3 _pos;
    private Vector3 _default;

    public bool isPlaneLive;
    
    void Start()
    {
        _default = new Vector3(0, 0, -0.75f);
        _move = _default;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaneLive)
        {
            _pos = this.transform.position;
            this.transform.position = _pos + _move;
        }
    }

    public void SetSpeed(float i)
    {
        _move = _default * i;
    }
}
