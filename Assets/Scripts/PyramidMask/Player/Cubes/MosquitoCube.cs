using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PyramidMask
{
    public class MosquitoCube : Cube
    {
        [SerializeField] 
        private List<Transform> flyPoints;

        [SerializeField] 
        private float moveSpeed = 10f;

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
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerController>().GetMosquitoCubeHurt();
                ReleaseMosquitoCube();
            }
            if (other.CompareTag("AnotherPlayer"))
            {
                other.GetComponent<AnotherPlayerController>().GetMosquitoCubeHurt();
                ReleaseMosquitoCube();
            }
        }

        public void ReleaseMosquitoCube()
        {
            foreach (var point in flyPoints)
            {
                point.gameObject.SetActive(false);
            }
            gameObject.SetActive(false);
        }
    }
}
