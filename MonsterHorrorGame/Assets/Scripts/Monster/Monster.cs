using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Waypoints;

public class Monster : MonoBehaviour
{
    public Transform player;

    public float timer = 20f;

    [SerializeField] bool spotted = false;

    [Range(0, 360)]
    public float fovAngle;
    public float radius;

    public float speed;
    public float fovSpeed;

    [SerializeField] float dist;

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
        speed = GetComponent<NavMeshAgent>().speed = 2f;

        nav = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();

        StartCoroutine("FindTargetsWithDelay", .2f);        
    }

    void Update()
    {
        dist = Vector3.Distance(transform.position, player.transform.position);

        Look();

        timer -= Time.deltaTime;

        if(timer <= 0 && spotted == false && dist > 20)
        {
            Destroy(gameObject);
        }

        if(fovAngle > 60 && spotted == false)
        {
            fovAngle -= fovSpeed * Time.deltaTime;
        }
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
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
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < fovAngle / 2) 
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    spotted = true;
                    visibleTargets.Add(target);
                    fovAngle += fovSpeed * Time.deltaTime;
                    Chase();
                    Debug.Log("Spotted");
                }
                else
                {
                    spotted = false;
                }
            }
            else
            {
                spotted = false;
            }
        }
    }

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
                timer += Time.deltaTime;
            }
        }
    }

    void Chase()
    {
        if(spotted == true)
        {
            speed = GetComponent<NavMeshAgent>().speed = 5f;

            Vector3 dirToPlayer = transform.position - player.transform.position;

            Vector3 newPos = transform.position - dirToPlayer;

            nav.SetDestination(newPos);
        }
    }

    void Attack()
    {

    }
}