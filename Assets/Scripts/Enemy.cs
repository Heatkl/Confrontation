using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Transform target;
    private int rewardPerEnemy = 50;


    
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        Player.instance.AddEnemy(gameObject.transform);
        target = Player.instance.GetNearArmy();
    }


    private void Update()
    {
        if (target != null)
        {
            navMeshAgent.SetDestination(target.position);
        }
        else
        {
            target = Player.instance.GetNearArmy();
        }
    }

    private void OnDestroy()
    {
        Player.instance.RemoveEnemy(gameObject.transform);
        Player.instance.CoinsQuantity += rewardPerEnemy;
    }
}
