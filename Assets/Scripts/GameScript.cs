using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject environment;
    [SerializeField] private GameObject _vcam1;
    
    private AnimatorScript _animator;
    private InputController _input;
    private Environment _environment;

    public bool isLive = false;
    
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
        _vcam1.SetActive(false);
    }
    public void Run()
    {
        _animator.startRunning();
        _environment.SetSpeed(2.5f);
    }

    public void Walk()
    {
        _animator.startWalking();
        _environment.SetSpeed(0.45f);
    }
}
