using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PyramidMask
{
    public class AnotherPlayerSkillContainer : BaseSkillContainer
    {
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SkillExcuter(currentSkillType);
            }
        }
    }
}