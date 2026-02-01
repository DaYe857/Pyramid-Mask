using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PyramidMask
{
    public class WindCube : Cube
    {
        public WindCube anotherWindCube;

        [SerializeField] 
        private float transferCD = 3f;
        public bool canTransfer = true;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && canTransfer)
            {
                other.GetComponent<PlayerController>().GetWindCubeHurt(this);
                SetTransfer();
            }
            if (other.CompareTag("AnotherPlayer") && canTransfer)
            {
                other.GetComponent<AnotherPlayerController>().GetWindCubeHurt(this);
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