using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PyramidMask
{
    public class PlayerController : MonoBehaviour
    { 
        [Header("移动设置")]
        public float moveDistance = 2.0f;      // 每次按键移动的固定距离
        public float moveSpeed = 5.0f;         // 移动速度（用于平滑移动）
        public LayerMask obstacleLayer;        // 障碍物图层（在Inspector中设置）

        public Vector3 targetPosition;        // 目标位置
        public bool isMoving = false;         // 移动状态标志
        private Vector3 moveDirection;         // 当前移动方向
        
        
        [SerializeField]
        private PlayerStateView playerStateView;
        [SerializeField]
        private PlayerCheckArea playerCheckArea;

        [SerializeField] 
        private GameObject darkCubesPrefab;
        [SerializeField]
        private GameObject animalCubesPrefab;
        public Transform spawnPosition;
        private bool canMove = true;
        public bool isBlooded = false;
        public bool isBandage = false;

        public float mosquitoCD = 30f;
        private Animator anim;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        void Update()
        {
            if (canMove)
            {
                HandleInput();
                HandleMovement();
            }
        }

        // 处理WASD输入
        private void HandleInput()
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

        // 尝试移动：发射射线检测障碍物
        private void AttemptMove(Vector3 direction)
        {
            // 将方向转换到世界坐标系（考虑物体旋转）
            moveDirection = transform.TransformDirection(direction);
            float rayDistance = moveDistance;

            // 发射射线检测障碍物
            RaycastHit hit;
            if (Physics.Raycast(transform.position, moveDirection, out hit, moveDistance, obstacleLayer))
            {
             // 如果命中障碍物，调整移动距离（减去一小段缓冲距离）
                rayDistance = 0f;
            }
            // 计算目标位置
            targetPosition = transform.position + moveDirection * rayDistance;
            isMoving = true;
        }

        // 处理平滑移动
        private void HandleMovement()
        {
            if (!isMoving) return;
            
            // 使用 Lerp 或 MoveTowards 平滑移动
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // 检查是否到达目标位置
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                transform.position = targetPosition; // 确保位置精确
                isMoving = false;
            }
    }

        // 可视化调试射线（在Scene视图中显示）
        private void OnDrawGizmosSelected()
        {
            if (isMoving)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(transform.position, targetPosition);
            }
        }
        
        /// <summary>
        /// 受到雹灾
        /// </summary>
        public void GetSnowCubeHurt()
        {
            canMove = false;
            transform.position = spawnPosition.position;
            targetPosition = transform.position;
            canMove = true;
        }

        /// <summary>
        /// 受到蛙灾
        /// </summary>
        /// <param name="windCube"></param>
        public void GetWindCubeHurt(WindCube windCube)
        {
            canMove = false;
            windCube.anotherWindCube.SetTransfer();
            transform.position = windCube.anotherWindCube.transform.position;
            targetPosition = transform.position;
            canMove = true;
        }
        public void RecoverWindCubeHurt()
        {
            List<GameObject> obj = playerCheckArea.checkAreaObj;
            foreach (var cube in obj)
            {
                if(cube.GetComponent<WindCube>()) cube.gameObject.SetActive(false);
            }
        }

        public void RecoverPlantCubeHurt()
        {
            List<GameObject> obj = playerCheckArea.checkAreaObj;
            foreach (var cube in obj)
            {
                if(cube.GetComponent<PlantCube>()) cube.gameObject.SetActive(false);
            }
        }

        public void RecoverSnowCubeHurt()
        {
            List<GameObject> obj = playerCheckArea.checkAreaObj;
            foreach (var cube in obj)
            {
                if(cube.GetComponent<SnowCube>()) cube.gameObject.SetActive(false);
            }
            Instantiate(darkCubesPrefab, transform.position, Quaternion.identity);
        }

        /// <summary>
        /// 受到畜疫灾
        /// </summary>
        public void GetAnimalCubeHurt() => StartCoroutine(AnimalState());

        IEnumerator AnimalState()
        {
            moveSpeed = 2.5f;
            yield return new WaitForSeconds(20f);
            moveSpeed = 5f;
        }
        public void RecoverAnimalCubeHurt() => moveSpeed = 5f;

        /// <summary>
        /// 受到血灾
        /// </summary>
        /// <param name="bloodCube"></param>
        public void GetBloodCubeHurt()
        {
            isBlooded = true;
            playerStateView.SetBloodedState(isBlooded);
        }

        public void RecoverBloodCubeHurt()
        {
            List<GameObject> obj = playerCheckArea.checkAreaObj;
            foreach (var cube in obj)
            {
                if(cube.GetComponent<BloodCube>()) cube.gameObject.SetActive(false);
            }
        }

        public void GetBandageCubeHurt() => StartCoroutine(BandageState());

        IEnumerator BandageState()
        {
            isBandage = true;
            playerStateView.SetBandageState(isBandage);
            yield return new WaitForSeconds(20f);
            isBandage = false;
            playerStateView.SetBandageState(isBandage);
        }

        public void RecoverBandageCubeHurt()
        {
            isBandage = false;
            playerStateView.SetBandageState(isBandage);
        }

        public void RecoverDarkCubeHurt()
        {
            List<GameObject> obj = playerCheckArea.checkAreaObj;
            foreach (var cube in obj)
            {
                if(cube.GetComponent<DarkCube>()) cube.gameObject.SetActive(false);
            }
        }
        public void GetMosquitoCubeHurt() => StartCoroutine(MousquitoState());
        IEnumerator MousquitoState()
        {
            yield return new WaitForSeconds(8f);
            canMove = false;
            yield return new WaitForSeconds(2f);
            canMove = true;
            
            yield return new WaitForSeconds(8f);
            canMove = false;
            yield return new WaitForSeconds(2f);
            canMove = true;
            
            yield return new WaitForSeconds(8f);
            canMove = false;
            yield return new WaitForSeconds(2f);
            canMove = true;
            isBlooded = false;
            playerStateView.SetBloodedState(isBlooded);
        }

        public void RecoverMosquitoCubeHurt()
        {
            isBlooded = false;
            playerStateView.SetBloodedState(isBlooded);
            StopCoroutine(MousquitoState());
        }

        public void GetFlyCubeHurt() => StartCoroutine(FlyState());
        IEnumerator FlyState()
        {
            canMove = false;
            yield return new WaitForSeconds(8f);
            canMove = true;
        }

        public void RecoverFlyCubeHurt()
        {
            List<GameObject> obj = playerCheckArea.checkAreaObj;
            foreach (var cube in obj)
            {
                if (cube.GetComponent<FlyCube>())
                {
                    FlyCube flyCube = cube.GetComponent<FlyCube>();
                    Vector3 targetPosition = new Vector3(flyCube.currentPoints.position.x, flyCube.currentPoints.position.y - 1, flyCube.currentPoints.position.z);
                    Instantiate(animalCubesPrefab, targetPosition, Quaternion.identity);
                    flyCube.ReleaseFlyCube();
                }
            }
        }
    }
}