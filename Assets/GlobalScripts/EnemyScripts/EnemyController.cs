using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent agent;
    [HideInInspector]
    public Transform player;
    private Vector3 destination;
    public float maintainDistance;
    public float shootRange;
    public float searchRadius;
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
            if((transform.position - player.position).magnitude <= maintainDistance)
            {
                agent.SetDestination(transform.position);
            }
            else
            {
                agent.SetDestination(destination);
            }
            transform.LookAt(player);
            transform.eulerAngles = new Vector3(0f,transform.eulerAngles.y,transform.eulerAngles.z);
        }
        else
        {
            agent.ResetPath();
        }
        destination = Vector3.Lerp(destination,player.position,0.8f);
    }
}
