using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class SFXButton : MonoBehaviour
{
    private bool _sfx;
    private int _number;
    
    [SerializeField] private Sprite _onSprite;
    [SerializeField] private Sprite _offSprite;

    private GameObject _button;

    private GameScript _gameScript;
    
    void Start()
    {
        _gameScript = GameObject.FindWithTag("Game").GetComponent<GameScript>();
        
        _button = this.gameObject;
        _number = PlayerPrefs.GetInt("sfx", 1);
        if (_number == 1)
        {
            _sfx = true;
            _button.GetComponent<Image>().sprite = _onSprite;
        }
        else
        {
            _sfx = false;
            _button.GetComponent<Image>().sprite = _offSprite;
        }
    }

    public void OnTouch()
    {
        _gameScript.buttonClick();
        if (_sfx == true)
        {
            _sfx = false;
            _gameScript.sfxOff();
            _button.GetComponent<Image>().sprite = _offSprite;
        }
        else
        {
            _sfx = true;
            _gameScript.sfxOn();
            _button.GetComponent<Image>().sprite = _onSprite;
        }
    }
}