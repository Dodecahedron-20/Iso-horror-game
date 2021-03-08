using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public Transform player;
    public bool spotted;
    public float fovAngle = 90f;
    public float circ;
    public float speed;
    public float chaseSpeed;
    public float patrolTime;
    public Transform[] patrolWayPoints;
    //private bool rememberPlayer;
    //public float memoryTime = 10f;
    //private float increasingMemoryTime;

    private NavMeshAgent nav;

    Rigidbody rb;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, circ);
        
        foreach(var Player in hitColliders)
        {
            if(Player.gameObject.tag == "Player")
            {
                Debug.Log("Detected");
            }
        }

    }

    void Search()
    {

    }

    void Chase()
    {

    }

    void Attack()
    {

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, circ);
    }
}
