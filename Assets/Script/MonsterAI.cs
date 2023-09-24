using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    [Range(0.5f,50)]
    public float directionDistance = 5;
    public Transform[] points;
    private NavMeshAgent agent;
    private Transform player;
    private float defaultSpeed = 1.5f;
    public Vector3 defaultMobSize;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        defaultMobSize = transform.GetChild(0).transform.localScale;
        if (agent != null)
            agent.destination = points[0].position ;
    }

    private void Update()
    {
        Walk();
        SearchPlayer();
        changeMobSize();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, directionDistance);
    }


    private void Walk()
    {
        float distance = agent.remainingDistance;
        if (distance <= 0.5f)
            agent.destination = points[Random.Range(0, 2)].position;
    }

    private void SearchPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        
        if (distanceToPlayer <= directionDistance)
        {
            agent.destination = player.position;
            agent.speed += .5f;
        }else 
            agent.speed = defaultSpeed;
    }

    private void changeMobSize()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if(transform.childCount != 0)
        {
            if (distanceToPlayer <= directionDistance)
                transform.GetChild(0).transform.localScale = new Vector3(79, 35, 13);
            else if (distanceToPlayer > directionDistance)
                transform.GetChild(0).transform.localScale = defaultMobSize;
        }
    }
}
