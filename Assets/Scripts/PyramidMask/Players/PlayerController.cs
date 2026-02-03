using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PyramidMask
{
    public class PlayerController : BasePlayerController
    { 
        // 处理WASD输入
        public override void HandleInput()
        {
            if (isMoving) return; // 如果正在移动，忽略新输入

            Vector3 inputDirection = Vector3.zero;
            if (isBandage)
            {
                float h = Input.GetAxis("Player1Horizontal");
                float v = Input.GetAxis("Player1Vertical");
                if (h < 0) inputDirection = -Vector3.left;
                if (h > 0) inputDirection = -Vector3.right;
                if(v < 0) inputDirection = -Vector3.back;
                if (v > 0) inputDirection = -Vector3.forward;
            }
            else
            {
                float h = Input.GetAxis("Player1Horizontal");
                float v = Input.GetAxis("Player1Vertical");
                if (h < 0) inputDirection = Vector3.left;
                if (h > 0) inputDirection = Vector3.right;
                if(v < 0) inputDirection = Vector3.back;
                if (v > 0) inputDirection = Vector3.forward;
            }
            
            if (inputDirection != Vector3.zero) AttemptMove(inputDirection);
        }
    }
}