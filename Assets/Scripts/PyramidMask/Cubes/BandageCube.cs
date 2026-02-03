using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PyramidMask
{
    public class BandageCube : BaseCube
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<BasePlayerController>() != null)
            {
                BasePlayerController player = other.GetComponent<BasePlayerController>();
                if (player is PlayerController)
                {
                    PlayerController playerController = player as PlayerController;
                    playerController.GetBandageCubeHurt();
                }
                
                if (player is AnotherPlayerController)
                {
                    AnotherPlayerController playerController = player as AnotherPlayerController;
                    playerController.GetBandageCubeHurt();
                }
            }
        }
    }
}

