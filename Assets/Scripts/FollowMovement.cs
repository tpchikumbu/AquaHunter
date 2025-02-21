using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
      if (target != null)
      {
        agent.SetDestination(target.position);
      } else {
        agent.SetDestination(transform.position + new Vector3(50, 70, 0));
      }        
    }
}
