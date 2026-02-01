using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PyramidMask
{
    public class SnowCube : Cube
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerController>().GetSnowCubeHurt();
            }
            if (other.CompareTag("AnotherPlayer"))
            {
                other.GetComponent<AnotherPlayerController>().GetSnowCubeHurt();
            }
        }
    }
}