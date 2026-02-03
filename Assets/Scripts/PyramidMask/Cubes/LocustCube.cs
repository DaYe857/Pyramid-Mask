using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PyramidMask
{
    public class LocustCube : BaseCube
    {
        [SerializeField] 
        private List<GameObject> locustCubeTypes;

        private void Start()
        {
            InvokeRepeating(nameof(ChangeLocustCubeType), 0f, 10f);
        }

        private void ChangeLocustCubeType()
        {
            foreach (GameObject go in locustCubeTypes)
            {
                go.SetActive(false);
            }
            GameObject obj = locustCubeTypes[Random.Range(0, locustCubeTypes.Count)];
            obj.SetActive(true);
        }
    }
}