using System;
using System.Collections;
using System.Collections.Generic;
using MyCompany.GameFramework.EnemyAI;
using UnityEngine;
using UnityEngine.AI;

namespace MyCompany.MyGame.Enemies
{
    public class BasicEnemy : MonoBehaviour
    {
        protected IMovementBehaviour movementBehaviour;

        protected Dictionary<IActionCondition, IEnemyAbility> abilities =
            new Dictionary<IActionCondition, IEnemyAbility>();

        protected NavMeshAgent agent;

        protected GameObject player;

        private void Awake()
        {
            agent = gameObject.GetComponent<NavMeshAgent>();
            player = GameObject.FindWithTag("Player");
            
            /* Initializing interfaces */
            movementBehaviour = new RoamBehavior(agent, 5);
            AddDashAbility();
        }

        private void Update()
        {
            if (!agent.hasPath)
            {
                movementBehaviour.SetNextTargetPostion();
            }

            CheckCondition();
        }
    }
}
