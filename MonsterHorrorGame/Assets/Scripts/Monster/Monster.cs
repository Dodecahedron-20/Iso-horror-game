using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Waypoints;

public class Monster : MonoBehaviour
{
    public GameObject player;

    public bool spotted = false;

    public float fovAngle;
    [Range(0, 360)]
    public float currentFOVAngle;
    public float radius;

    [SerializeField] float walkSpeed = 3f;
    [SerializeField] float runSpeed = 5f;
    public float fovSpeed;

    public float dist;

    public float damage;

    public List<Transform> visibleTargets = new List<Transform>();

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    [SerializeField] private Vector3 lastKnownPos;
    [SerializeField] Color sightColour = new Color(207, 169, 255, 255);

    private NavMeshAgent nav;

    Rigidbody rb;

    RaycastHit hit;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        nav = GetComponent<NavMeshAgent>();

        rb = GetComponent<Rigidbody>();

        StartCoroutine("FindTargetsWithDelay", 0.5f);

        currentFOVAngle = fovAngle;

        nav.speed = walkSpeed;
    }

    void Update()
    {
        dist = Vector3.Distance(transform.position, player.transform.position);  
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (spotted == false)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    //Checks to see if there is a target within it's field of view angle using a raycast
    void FindVisibleTargets()
    {
        Debug.Log("hey im lookin here");
        visibleTargets.Clear();

        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, radius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Transform playerTargetPoint = player.transform;
            //Vector3 dirToTarget = (playerTargetPoint.position - (transform.position - transform.forward)).normalized;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < currentFOVAngle / 2) 
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    spotted = true;
                    visibleTargets.Add(target);
                    lastKnownPos = playerTargetPoint.position;
                    currentFOVAngle = Mathf.Clamp(currentFOVAngle + fovSpeed * Time.deltaTime, 60f, 180f);
                    Chase();
                    Debug.Log("Spotted");                    
                }
                else
                {
                    Vector3 dirToPlayer = transform.position - lastKnownPos;

                    Vector3 newPos = transform.position - dirToPlayer;

                    nav.SetDestination(newPos);

                    //currentFOVAngle = Mathf.Clamp(currentFOVAngle - fovSpeed * Time.deltaTime, 60f, 180f);
                    //Invoke("SetBoolFalse", 3f);
                }
            }
            //else
            //{
            //    Invoke("SetBoolFalse", 3f);
            //}
        }
    }

    //void SetBoolFalse()
    //{
    //    spotted = false;
    //    nav.speed = walkSpeed;
    //}

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    //Checks if player is within range of enemy
    void Look()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

        foreach (var Player in hitColliders)
        {
            if (Player.gameObject.tag == "Player")
            {

            }
        }
    }

    void Chase()
    {
        if (spotted == true)
        {
            nav.speed = runSpeed;

            Vector3 dirToPlayer = transform.position - player.transform.position;

            Vector3 newPos = transform.position - dirToPlayer;

            nav.SetDestination(newPos);
        }
    }

    void OnTriggerEnter(Collider player)
    {
        if(player.gameObject.tag == "Player")
        {
            Debug.Log("pow");
            player.gameObject.GetComponent<Player>().health -= damage;
        }
    }
}