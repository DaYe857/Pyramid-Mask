using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PyramidMask
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;

        private void Awake()
        {
            if(instance == null)instance = this;
            else Destroy(gameObject);
        }
        
        public void ExitGame() => Application.Quit();
    }
}