using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PyramidMask
{
    public class PlayerStateView : MonoBehaviour
    {
        [SerializeField] 
        private Image bandageState;

        [SerializeField] 
        private Image bloodedState;

        private void Awake()
        {
            bandageState.color = new Color(225f,225f,225f,0.5f);
            bloodedState.color = new Color(225f,225f,225f,0.5f);
        }

        public void SetBandageState(bool state)
        {
            if(state) bandageState.color = new Color(225f,225f,225f,1f);
            else bandageState.color = new Color(225f,225f,225f,0.5f);
        }
        
        public void SetBloodedState(bool state)
        {
            if(state) bloodedState.color = new Color(225f,225f,225f,1f);
            else bloodedState.color = new Color(225f,225f,225f,0.5f);
        }
    }
}

