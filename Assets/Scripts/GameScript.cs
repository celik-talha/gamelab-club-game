using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject environment;
    [SerializeField] private GameObject _vcam1;
    [SerializeField] private GameObject _vcam2;
    
    private AnimatorScript _animator;
    private InputController _input;
    private Environment _environment;

    public bool isLive = false;
    public int status = 1;
    
    void Start()
    {
        _animator = player.GetComponent<AnimatorScript>();
        _input = player.GetComponent<InputController>();
        _environment = environment.GetComponent<Environment>();
        
        isLive = true;
        _environment.isPlaneLive = false;
    }

    void Update()
    {
    }

    public void StartGame()
    {
        _environment.isPlaneLive = true;
        Run();
        _vcam2.SetActive(true);
        _vcam1.SetActive(false);
    }
    public void Run()
    {
        status = 1;
        _animator.startRunning();
        _environment.SetSpeed(1.5f);//22s
    }

    public void Walk()
    {
        status = 0;
        _animator.startWalking();
        _environment.SetSpeed(0.45f);
    }

    public void Idle()
    {
        _animator.startIdle();
        _environment.SetSpeed(0f);
    }

    public void Hit()
    {
        Walk();
    }

    public void getPhone()
    {
        
    }

    public void preFinish()
    {
        Walk();
    }

    public void Finish()
    {
        Idle();
    }
}
