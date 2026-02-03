using System;
using System.Collections;
using System.Collections.Generic;
using PyramidMask;
using UnityEngine;

public class PlayerCheckArea : MonoBehaviour
{
    public List<GameObject> checkAreaObj;

    private void Awake()
    {
        checkAreaObj = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BaseCube>())
        {
            checkAreaObj.Add(other.gameObject);
            Debug.Log(other.gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        checkAreaObj.Remove(other.gameObject);
    }
}
