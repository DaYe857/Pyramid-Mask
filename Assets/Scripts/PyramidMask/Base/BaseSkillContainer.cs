using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PyramidMask
{
    public class BaseSkillContainer : MonoBehaviour
    {
        [Serializable]
        public class SkillType
        {
            public SkillData data;
            public bool active;

            public SkillType(SkillData data, bool active)
            {
                this.data = data;
                this.active = active;
            }
        }
        
        public ESkillType currentSkillType;
        public Image currentSkillImage;
        private int currentSkillIndex = -1;
        
        [SerializeField]
        private List<SkillType> currentSkillTypes;
        [SerializeField]
        private SkillDataManager skillDataManager;
        private List<SkillData> skillDatas;
        
        private BasePlayerController basePlayerController;

        private void Awake()
        {
            currentSkillTypes = new List<SkillType>();
            skillDatas = skillDataManager.GetSkillDataList();
            
            basePlayerController = GetComponent<BasePlayerController>();
        }

        private void Start()
        {
            InvokeRepeating(nameof(RepeatSkill),2f,2f);
        }

        protected void SkillExcuter(ESkillType currentSkillType)
        {
            switch (currentSkillType)
            {
                case ESkillType.ANIMAL:
                    basePlayerController.RecoverFlyCubeHurt();
                    break;
                case ESkillType.BANDAGE:
                    basePlayerController.RecoverAnimalCubeHurt();
                    break;
                case ESkillType.BLOOD:
                    basePlayerController.RecoverMosquitoCubeHurt();
                    break;
                case ESkillType.FLY:
                    basePlayerController.RecoverBandageCubeHurt();
                    break;
                case ESkillType.LOCUTS:
                    basePlayerController.RecoverPlantCubeHurt();
                    break;
                case ESkillType.MOSQUITO:
                    basePlayerController.RecoverWindCubeHurt();
                    break;
                case ESkillType.SNOW:
                    basePlayerController.RecoverBloodCubeHurt();
                    break;
                case ESkillType.WIND:
                    basePlayerController.RecoverDarkCubeHurt();
                    break;
                case ESkillType.DARK:
                    basePlayerController.RecoverSnowCubeHurt();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// 激活技能
        /// </summary>
        /// <param name="skillType">技能类型</param>
        /// <param name="value">技能状态</param>
        public void SetSkillTrue(ESkillType skillType)
        {
            foreach (var data in skillDatas)
            {
                if (data.skillType == skillType)
                {
                    SkillType skt = new SkillType(data, true);
                    currentSkillTypes.Add(skt);
                }
            }
        }

        private void RepeatSkill()
        {
            if(currentSkillTypes.Count == 0) return;
            currentSkillIndex++;
            if (currentSkillIndex >= currentSkillTypes.Count)
            {
                currentSkillIndex = 0;
            }
            currentSkillType = currentSkillTypes[currentSkillIndex].data.skillType;
            currentSkillImage.sprite = currentSkillTypes[currentSkillIndex].data.skillIcon;
        }
    }
}