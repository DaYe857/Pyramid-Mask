using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PyramidMask
{
    public class BandageCube : Cube
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerController>().GetBandageCubeHurt();
            }
            if (other.CompareTag("AnotherPlayer"))
            {
                other.GetComponent<AnotherPlayerController>().GetBandageCubeHurt();
            }
        }
    }
}

