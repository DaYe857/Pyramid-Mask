using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetXY : MonoBehaviour
{
    public Material material;

    public float offsetSpeed = 0.1f;

    public bool moveX, moveY;

    private void Update()
    {
        if (material != null)
        {
            var offset = material.mainTextureOffset;
            if(moveX) offset.x += offsetSpeed * Time.deltaTime;
            if (moveY) offset.y += offsetSpeed * Time.deltaTime;
            material.mainTextureOffset = offset;
        }
    }
}
