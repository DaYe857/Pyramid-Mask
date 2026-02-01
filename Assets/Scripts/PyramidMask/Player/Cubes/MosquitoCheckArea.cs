using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PyramidMask
{
    public class MosquitoCheckArea : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (other.GetComponent<PlayerController>().isBlooded)
                {
                    other.GetComponent<PlayerController>().GetMosquitoCubeHurt();
                    transform.parent.GetComponent<MosquitoCube>().ReleaseMosquitoCube();
                }
            }
            if (other.CompareTag("AnotherPlayer"))
            {
                if (other.GetComponent<AnotherPlayerController>().isBlooded)
                {
                    other.GetComponent<AnotherPlayerController>().GetMosquitoCubeHurt();
                    transform.parent.GetComponent<MosquitoCube>().ReleaseMosquitoCube();
                }
            }
        }
    }
}