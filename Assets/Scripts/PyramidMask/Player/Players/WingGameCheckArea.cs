using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingGameCheckArea : MonoBehaviour
{
    [SerializeField] 
    private GameObject wingGamePanel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("AnotherPlayer"))
        {
            Time.timeScale = 1f;
            wingGamePanel.SetActive(true);
        }
    }
}
