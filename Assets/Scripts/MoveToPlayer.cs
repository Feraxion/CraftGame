using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPlayer : MonoBehaviour
{
    [SerializeField]private NavMeshAgent agent;



    private void Awake()
    {
        agent = gameObject.GetComponentInChildren<NavMeshAgent>(); 
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Building")
        {
            agent.destination = other.transform.position;
        }
        if (other.tag == "Player")
        {
            agent.destination = other.transform.position;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Building")
        {
            agent.destination = other.transform.position;
        }    
    }


    void Start ()
    {
       // agent.destination = Vector3.zero;
    }

}

