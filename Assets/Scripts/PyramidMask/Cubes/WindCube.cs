using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PyramidMask
{
    public class WindCube : BaseCube
    {
        public WindCube anotherWindCube;

        [SerializeField] 
        private float transferCD = 3f;
        public bool canTransfer = true;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<BasePlayerController>() != null && canTransfer)
            {
                BasePlayerController player = other.GetComponent<BasePlayerController>();
                if (player is PlayerController)
                {
                    PlayerController playerController = player as PlayerController;
                    playerController.GetWindCubeHurt(this);
                }
                
                if (player is AnotherPlayerController)
                {
                    AnotherPlayerController playerController = player as AnotherPlayerController;
                    playerController.GetWindCubeHurt(this);
                }
                SetTransfer();
            }
        }

        public void SetTransfer() => StartCoroutine(TransferCD());

        IEnumerator TransferCD()
        {
            canTransfer = false;
            yield return new WaitForSeconds(3f);
            canTransfer = true;
        }
    }
}