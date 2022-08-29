using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject environment;
    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject _vcam1;
    [SerializeField] private GameObject _vcam2;

    [SerializeField] private GameObject scoreObject;
    private TextMeshProUGUI scoreText;

    [SerializeField] private GameObject startPanel;
    
    private AnimatorScript _animator;
    private InputController _input;
    private Environment _environment;
    private SpawnManager _spawnManager;

    public bool isLive = false;
    public int status = 1;

    private bool _started = false;

    private int _score;
    
    
    
    void Start()
    {
        _animator = player.GetComponent<AnimatorScript>();
        _input = player.GetComponent<InputController>();
        _environment = environment.GetComponent<Environment>();
        _spawnManager = spawner.GetComponent<SpawnManager>();
        scoreText = scoreObject.GetComponent<TextMeshProUGUI>();
        
        isLive = true;
        _environment.isPlaneLive = false;

        _score = PlayerPrefs.GetInt("score",0);
        scoreText.text = _score.ToString();

    }

    void Update()
    {
        if (Input.touchCount > 0 && _started == false)
        {
            _started = true;
            startPanel.SetActive(false);
        }
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

    public void stopSpawn()
    {
        _spawnManager.letSpawn = false;
    }
}
