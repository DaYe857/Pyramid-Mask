using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PyramidMask
{
    public class FlyCube : BaseCube
    {
        [SerializeField] 
        private List<Transform> flyPoints;

        [SerializeField] 
        private float moveSpeed = 10f;

        public Transform currentPoints;

        private int currentPointIndex = 0;
        private bool pointState = false;
        

        private void Start()
        {
            InvokeRepeating(nameof(RepeatMove),2f,2f);
        }

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, flyPoints[currentPointIndex].position, moveSpeed * Time.deltaTime);
        }

        private void RepeatMove()
        {
            if(flyPoints.Count == 0)return;
            if (currentPointIndex == 0) pointState = false;
            if(currentPointIndex == flyPoints.Count - 1) pointState = true;
            if(pointState) currentPointIndex--;
            else currentPointIndex++;
            currentPoints = flyPoints[currentPointIndex];
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<BasePlayerController>() != null)
            {
                BasePlayerController player = other.GetComponent<BasePlayerController>();
                if (player is PlayerController)
                {
                    PlayerController playerController = player as PlayerController;
                    playerController.GetFlyCubeHurt();
                }
                if (player is AnotherPlayerController)
                {
                    AnotherPlayerController playerController = player as AnotherPlayerController;
                    playerController.GetFlyCubeHurt();
                }
                
                ReleaseFlyCube();
            }
        }

        public void ReleaseFlyCube()
        {
            foreach (var point in flyPoints)
            {
                point.gameObject.SetActive(false);
            }
            gameObject.SetActive(false);
        }
    }
}

