using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unpause : MonoBehaviour
{
   private GameScript _gameScript;

   private void Start()
   {
      _gameScript = GameObject.FindWithTag("Game").GetComponent<GameScript>();
   }

   public void click()
   {
      _gameScript.UnPaused();
      _gameScript.buttonClick();
   }
}
