using System;
using System.Collections;
using System.Collections.Generic;
using PyramidMask;
using UnityEngine;

public class WingGameCheckArea : MonoBehaviour
{
    [SerializeField] 
    private GameObject wingGamePanel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BasePlayerController>())
        {
            Time.timeScale = 1f;
            wingGamePanel.SetActive(true);
        }
    }
}
