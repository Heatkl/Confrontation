using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Archer : MonoBehaviour
{

    private NavMeshAgent navMeshAgent;
    private Transform target;
    private Vector3 oldPosition;
    private float timeBetweenShoot = 1f;
    private float lastShotTime = 0f;

    [SerializeField] private GameObject arrowPrefab;

    void Start() => oldPosition = transform.position;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        Player.instance.AddArmy(gameObject.transform);
        target = Player.instance.GetNearEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        lastShotTime += Time.deltaTime;

        if (target != null)
        {
            navMeshAgent.SetDestination(target.position);
            if (lastShotTime > timeBetweenShoot)
            {
                lastShotTime = 0f;
                RangeAttack();
            }
              
        }
        else
        {
            target = Player.instance.GetNearEnemy();
        }
    }

    private void RangeAttack()
    {
        var speed = Vector3.Distance(transform.position, oldPosition);
        speed = Mathf.Abs(speed);
        oldPosition = transform.position;
        if (speed > 0.001f)
            return;
        ArrowShoot();
    }

    private void ArrowShoot()
    {
        var pref = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
        pref.transform.LookAt(target);
    }

    private void OnDestroy()
    {
        Player.instance.RemoveArmy(gameObject.transform);
    }
}


