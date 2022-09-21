using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject environment;
    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject _vcam1;
    [SerializeField] private GameObject _vcam2;

    [SerializeField] private GameObject scoreObject;
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI wonText;
    private TextMeshProUGUI wonPlusScoreText;
    [SerializeField] private GameObject wonTextObject;
    [SerializeField] private GameObject wonPlusScoreObject;

    [SerializeField] private GameObject startPanel;
    
    private AnimatorScript _animator;
    private InputController _input;
    private Environment _environment;
    private SpawnManager _spawnManager;
    private SoundManager _soundManager;

    [SerializeField] private GameObject soundObject;

    public bool isLive = false;
    public int status = 1;

    private bool _started = false;

    private int _score;

    private GameObject _currentTimer;

    [SerializeField] private GameObject objectUi;
    private Vector3 _uiPos;
    [SerializeField] private GameObject timerPrefab;

    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject endWonPanel;
    [SerializeField] private GameObject endLostPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject unpausePanel;
    private TextMeshProUGUI _countdownText;
    [SerializeField] private GameObject _countdownObject;
    
    public float _time;
    private float _hitTime;
    private bool hitStatus = false;

    private bool _phoneActive = false;

    private int _hitCount = 0;
    private int _tmp;

    private bool _finishPeriod = false;

    private int _countdownTime;
    void Start()
    {
        _soundManager = soundObject.GetComponent<SoundManager>();
        _uiPos = objectUi.transform.position;
        _animator = player.GetComponent<AnimatorScript>();
        _input = player.GetComponent<InputController>();
        _environment = environment.GetComponent<Environment>();
        _spawnManager = spawner.GetComponent<SpawnManager>();
        scoreText = scoreObject.GetComponent<TextMeshProUGUI>();
        wonText = wonTextObject.GetComponent<TextMeshProUGUI>();
        wonPlusScoreText = wonPlusScoreObject.GetComponent<TextMeshProUGUI>();
        _countdownText = _countdownObject.GetComponent<TextMeshProUGUI>();
        
        isLive = true;
        _environment.isPlaneLive = false;

        _score = PlayerPrefs.GetInt("score",0);
        scoreText.text = _score.ToString();

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (_finishPeriod == true)
            {
                nextRound();
            }
        }

        _time += Time.deltaTime * 1;

        if (hitStatus && _time > _hitTime + 3f)
        {
            Run();
            hitStatus = false;
        }
    }

    public void StartGame()
    {
        _started = true;
        startPanel.SetActive(false);
        _environment.isPlaneLive = true;
        Run();
        _vcam2.SetActive(true);
        _vcam1.SetActive(false);
        _time = 0f;
        gamePanel.SetActive(true);
    }
    public void Run()
    {
        status = 1;
        _animator.startRunning();
        _environment.SetSpeed(1f);//22s
    }

    public void Walk()
    {
        status = 0;
        _animator.startWalking();
        _environment.SetSpeed(0.5f);
    }

    public void Idle()
    {
        _animator.startIdle();
        _environment.SetSpeed(0f);
    }

    public void Hit()
    {
        if (_phoneActive == false)
        {
            Walk();
            hitStatus = true;
            _hitTime = _time;
            _hitCount++;
            _soundManager.hitSound();
        }
        else
        {
            _soundManager.hitSound();
        }
    }

    public void getPhone()
    {
        createTimer();
        _soundManager.phoneSound();
    }

    public void preFinish()
    {
        gamePanel.SetActive(false);
        Walk();
        if (_hitCount < 2)
        {
            _tmp = PlayerPrefs.GetInt("score", 0);
            if (_hitCount == 1)
            {
                wonText.text = "Right on time!";
                wonPlusScoreText.text = "+1";
                _tmp++;
            }

            if (_hitCount == 0)
            {
                wonText.text = "Perfect time!";
                wonPlusScoreText.text = "+2";
                _tmp = _tmp + 2;
            }
            PlayerPrefs.SetInt("score",_tmp);
            
            endWonPanel.SetActive(true);
        }
        else
        {
            endLostPanel.SetActive(true);
        }
        _finishPeriod = true;
    }

    public void Finish()
    {
        Idle();
    }

    public void stopSpawn()
    {
        _spawnManager.letSpawn = false;
    }

    public void timerEnd(GameObject _object)
    {
        Destroy(_object);
        _currentTimer = null;
        _phoneActive = false;
    }

    public void createTimer()
    {
        if (_currentTimer != null)
        {
            Destroy(_currentTimer);
        }
        _currentTimer = Instantiate(timerPrefab, _uiPos, Quaternion.identity);
        _currentTimer.transform.SetParent(gamePanel.transform);

        _phoneActive = true;
    }

    private void nextRound()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OpenSettings()
    {
        Time.timeScale = 0f;
        _environment.isPlaneLive = false;
        gamePanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void UnPaused()
    {
        settingsPanel.SetActive(false);
        unpausePanel.SetActive(true);
        _countdownTime = 4;
        
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        _countdownTime--;
        _countdownText.text = _countdownTime.ToString();
        
        yield return new WaitForSecondsRealtime(1f);
        
        _countdownTime--;
        _countdownText.text = _countdownTime.ToString();
        
        yield return new WaitForSecondsRealtime(1f);
        
        _countdownTime--;
        _countdownText.text = _countdownTime.ToString();
        
        yield return new WaitForSecondsRealtime(1f);
        
        unpausePanel.SetActive(false);
        Time.timeScale = 1f;
        _environment.isPlaneLive = true;
        gamePanel.SetActive(true);
        
    }

    public void musicOn()
    {
        _soundManager.PlayMusic();
    }

    public void musicOff()
    {
        _soundManager.StopMusic();
    }

    public void sfxOn()
    {
        _soundManager.PlaySfx();
    }

    public void sfxOff()
    {
        _soundManager.StopSfx();
    }

    public void buttonClick()
    {
        _soundManager.buttonSound();
    }
}
