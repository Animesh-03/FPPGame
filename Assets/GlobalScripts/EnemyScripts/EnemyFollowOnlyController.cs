using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowOnlyController : MonoBehaviour
{
    private NavMeshAgent agent;
    [HideInInspector]
    public Transform player;
    private float searchRadius = 12f;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if((transform.position - player.position).magnitude <= searchRadius)
        {
            agent.SetDestination(Vector3.Lerp(transform.position,player.position,0.8f));
        }
    }
}
