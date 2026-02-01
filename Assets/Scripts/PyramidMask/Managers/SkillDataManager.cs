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
        public static SkillDataManager instance;
        public List<SkillData> skillDataList;

        private void Awake()
        {
            if(instance == null) instance = this;
            else Destroy(gameObject);
        }
    }
}

