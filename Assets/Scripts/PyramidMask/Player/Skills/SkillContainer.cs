using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PyramidMask
{

    public class SkillContainer : MonoBehaviour
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
        private List<SkillData> skillDatas;
        
        private PlayerController playerController = null;
        private AnotherPlayerController anotherPlayerController = null;

        private void Awake()
        {
            currentSkillTypes = new List<SkillType>();
            skillDatas = SkillDataManager.instance.skillDataList;
            
            if (gameObject.CompareTag("Player")) playerController = GetComponent<PlayerController>();
            if (gameObject.CompareTag("AnotherPlayer")) anotherPlayerController = GetComponent<AnotherPlayerController>();
        }

        private void Start()
        {
            InvokeRepeating(nameof(RepeatSkill),2f,2f);
        }

        private void Update()
        {
            if(gameObject.CompareTag("Player"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    switch (currentSkillType)
                    {
                        case ESkillType.ANIMAL:
                            playerController.RecoverFlyCubeHurt();
                            break;
                        case ESkillType.BANDAGE:
                            playerController.RecoverAnimalCubeHurt();
                            break;
                        case ESkillType.BLOOD:
                            playerController.RecoverMosquitoCubeHurt();
                            break;
                        case ESkillType.FLY:
                            playerController.RecoverBandageCubeHurt();
                            break;
                        case ESkillType.LOCUTS:
                            playerController.RecoverPlantCubeHurt();
                            break;
                        case ESkillType.MOSQUITO:
                            playerController.RecoverWindCubeHurt();
                            break;
                        case ESkillType.SNOW:
                            playerController.RecoverBloodCubeHurt();
                            break;
                        case ESkillType.WIND:
                            playerController.RecoverDarkCubeHurt();
                            break;
                        case ESkillType.DARK:
                            playerController.RecoverSnowCubeHurt();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }

            if (gameObject.CompareTag("AnotherPlayer"))
            {
                if (Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    switch (currentSkillType)
                    {
                        case ESkillType.ANIMAL:
                            anotherPlayerController.RecoverFlyCubeHurt();
                            break;
                        case ESkillType.BANDAGE:
                            anotherPlayerController.RecoverAnimalCubeHurt();
                            break;
                        case ESkillType.BLOOD:
                            anotherPlayerController.RecoverMosquitoCubeHurt();
                            break;
                        case ESkillType.FLY:
                            anotherPlayerController.RecoverBandageCubeHurt();
                            break;
                        case ESkillType.LOCUTS:
                            anotherPlayerController.RecoverPlantCubeHurt();
                            break;
                        case ESkillType.MOSQUITO:
                            anotherPlayerController.RecoverWindCubeHurt();
                            break;
                        case ESkillType.SNOW:
                            anotherPlayerController.RecoverBloodCubeHurt();
                            break;
                        case ESkillType.WIND:
                            anotherPlayerController.RecoverDarkCubeHurt();
                            break;
                        case ESkillType.DARK:
                            anotherPlayerController.RecoverSnowCubeHurt();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
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