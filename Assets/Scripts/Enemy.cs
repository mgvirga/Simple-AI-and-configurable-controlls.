using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    public GameObject player;
    public Vector3 toTarget;
    public float speed = 1.5f;
    public float angle;
    public Vector3 direction;
   


    NavMeshAgent agent;

    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

    }


    public void Move()
    {
        GameObject destination = GameObject.FindGameObjectWithTag("Player");
        agent.SetDestination(destination.transform.position);

    }
    

    // Update is called once per frame
    void Update () {
        Move();
    }
}
