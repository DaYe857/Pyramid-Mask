using System;
using System.Collections;
using System.Collections.Generic;
using PyramidMask;
using UnityEngine;

namespace PyramidMask
{
    public enum ESkillType
    {
        ANIMAL,
        BANDAGE,
        BLOOD,
        FLY,
        LOCUTS,
        MOSQUITO,
        SNOW,
        WIND,
        DARK
    }
    
    public class SkillDataManager : MonoBehaviour
    {
        public List<SkillData> skillDataList;
        public List<SkillData> GetSkillDataList() => skillDataList;
    }
}

