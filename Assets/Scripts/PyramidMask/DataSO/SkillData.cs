using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PyramidMask
{
    [CreateAssetMenu(menuName = "Pyramid Mask/Skill Data")]
    public class SkillData : ScriptableObject
    {
        public ESkillType skillType;
        public Sprite skillIcon;
    }
}