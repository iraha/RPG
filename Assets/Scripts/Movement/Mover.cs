using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Combat;

namespace RPG.Movement 
{

    public class Mover : MonoBehaviour
    {

        [SerializeField] Transform target;

        NavMeshAgent navMeshAgent;

        private void Start() 
        {
            navMeshAgent = GetComponent<NavMeshAgent>();         
        }

        void Update()
        {
            UpdateAnimator();
        }

        public void StartMoveAction(Vector3 destination) // playerがtargetを変えた時の違う場所に行くための処理
        {
            GetComponent<Fighter>().Cancel();
            MoveTo(destination);
        }

        public void MoveTo(Vector3 destination)
        {
            navMeshAgent.destination = destination; // もしhit.point が押されたらplayerが移動targetに移動
            navMeshAgent.isStopped = false;　// 
        }

        public void Stop() 
        {

            navMeshAgent.isStopped = true; // playerをとまらせる

        }

        private void UpdateAnimator()
        {

            Vector3 velocity = navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;

            GetComponent<Animator>().SetFloat("forwardSpeed", speed);

        }
        //Debug.DrawRay(lastRay.origin, lastRay.direction * 100); 
        //help me watch raycast
    }


}