using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 30f;
    void Update() 
    {
        Vector3 angle = transform.localEulerAngles;
        angle.y += rotationSpeed * Time.deltaTime;
        transform.localEulerAngles = angle;
    }
}
