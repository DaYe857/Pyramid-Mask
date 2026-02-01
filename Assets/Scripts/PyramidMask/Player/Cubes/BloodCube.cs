using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PyramidMask
{
    public class BloodCube : Cube
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerController>().GetBloodCubeHurt();
            }
            if (other.CompareTag("AnotherPlayer"))
            {
                other.GetComponent<AnotherPlayerController>().GetBloodCubeHurt();
            }
        }
    }
}