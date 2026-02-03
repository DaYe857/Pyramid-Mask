using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PyramidMask
{
    public class MaskSkill : MonoBehaviour
    {
        [SerializeField]
        private ESkillType skillType;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<BasePlayerController>())
            {
                other.GetComponent<BaseSkillContainer>().SetSkillTrue(skillType);
                gameObject.SetActive(false);
            }
        }
    }
}

