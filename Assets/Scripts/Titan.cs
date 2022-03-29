using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Titan : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Transform target;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        Player.instance.AddArmy(gameObject.transform);
        target = Player.instance.GetNearEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            navMeshAgent.SetDestination(target.position);
        }
        else
        {
            target = Player.instance.GetNearEnemy();
        }
    }

    private void OnDestroy()
    {
        Player.instance.RemoveArmy(gameObject.transform);
    }
}
