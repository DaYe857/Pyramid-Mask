using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PyramidMask
{
    public class AnimalCube : Cube
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerController>().GetAnimalCubeHurt();
            }
        }
    }
}

