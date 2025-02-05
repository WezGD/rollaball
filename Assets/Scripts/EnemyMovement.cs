using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public Transform player;

    public bool followTarget = false;
    private bool sleepEnemy = false;

    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent= GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && followTarget && !sleepEnemy)
        {
            navMeshAgent.SetDestination(player.position);
        }
    }

    public void HitEnemy()
    {
        StartCoroutine(SleepEnemy());
    }

    private IEnumerator SleepEnemy()
    {
        sleepEnemy = true;
        navMeshAgent.SetDestination(transform.position);
        yield return new WaitForSeconds(5.0f);
        sleepEnemy = false;
    }
}
