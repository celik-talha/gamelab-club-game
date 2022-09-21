using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class MusicButton : MonoBehaviour
{
    private bool _music;
    private int _number;
    
    [SerializeField] private Sprite _onSprite;
    [SerializeField] private Sprite _offSprite;
    private GameScript _gameScript;

    private GameObject _button;
    
    void Start()
    {
        _gameScript = GameObject.FindWithTag("Game").GetComponent<GameScript>();
        
        _button = this.gameObject;
        _number = PlayerPrefs.GetInt("music", 1);
        if (_number == 1)
        {
            _music = true;
            _button.GetComponent<Image>().sprite = _onSprite;
        }
        else
        {
            _music = false;
            _button.GetComponent<Image>().sprite = _offSprite;
        }
    }

    public void OnTouch()
    {
        _gameScript.buttonClick();
        if (_music == true)
        {
            _music = false;
            _gameScript.musicOff();
            _button.GetComponent<Image>().sprite = _offSprite;
        }
        else
        {
            _music = true;
            _gameScript.musicOn();
            _button.GetComponent<Image>().sprite = _onSprite;
        }
    }
}
