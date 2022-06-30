using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void startRunning()
    {
        _animator.SetBool("isWalking",false);
        _animator.SetBool("isRunning",true);
    }

    public void startWalking()
    {
        _animator.SetBool("isRunning",false);
        _animator.SetBool("isWalking",true);
    }
    
    public void startIdle()
    {
        _animator.SetBool("isRunning",false);
        _animator.SetBool("isWalking",false);
        _animator.SetBool("isFinished",true);
    }
}
