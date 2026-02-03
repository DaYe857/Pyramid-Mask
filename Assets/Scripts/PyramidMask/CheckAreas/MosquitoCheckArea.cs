using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PyramidMask
{
    public class MosquitoCheckArea : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<BasePlayerController>() != null)
            {
                BasePlayerController player = other.GetComponent<BasePlayerController>();
                if (player.isBlooded)
                {
                    if (player is PlayerController)
                    {
                        PlayerController playerController = player as PlayerController;
                        playerController.GetMosquitoCubeHurt();
                    }
                
                    if (player is AnotherPlayerController)
                    {
                        AnotherPlayerController playerController = player as AnotherPlayerController;
                        playerController.GetMosquitoCubeHurt();
                    }
                    transform.parent.GetComponent<MosquitoCube>().ReleaseMosquitoCube();
                }
            }
        }
    }
}