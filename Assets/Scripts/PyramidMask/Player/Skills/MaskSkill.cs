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
            if (other.CompareTag("Player") || other.CompareTag("AnotherPlayer"))
            {
                other.GetComponent<SkillContainer>().SetSkillTrue(skillType);
                gameObject.SetActive(false);
            }
        }
    }
}

