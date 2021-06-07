using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Waypoints;

public class Monster : MonoBehaviour
{
    public GameObject player;

    public bool spotted = false;

    public bool remember = false;

    public float fovAngle;
    [Range(0, 360)]
    public float currentFOVAngle;
    public float radius;

    [SerializeField] float walkSpeed = 1.5f;
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float searchSpeed = 3.5f;
    public float fovSpeed;

    public float dist;

    public float damage;

    public List<Transform> visibleTargets = new List<Transform>();

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    [SerializeField] private Vector3 lastKnownPos;
    [SerializeField] Color sightColour = new Color(207, 169, 255, 255);

    public NavMeshAgent nav;

    Rigidbody rb;

    RaycastHit hit;

    [SerializeField]
    private Animator anim;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        nav = GetComponent<NavMeshAgent>();

        rb = GetComponent<Rigidbody>();

        StartCoroutine("FindTargetsWithDelay", 0.2f);

        currentFOVAngle = fovAngle;

        nav.speed = walkSpeed;

        if(anim != null)
        {
            anim.SetBool("run", false);
        }
    }

    void Update()
    {
        dist = Vector3.Distance(transform.position, player.transform.position);

        if (remember == true)
        {
            if (anim != null)
            {
                anim.SetBool("run", false);
            }

            Vector3 dirToPlayer = transform.position - player.transform.position;

            Vector3 newPos = transform.position - dirToPlayer;

            nav.speed = searchSpeed;

            nav.SetDestination(newPos);
        }
        else
        {
            if (spotted == false && remember == false)
            {
                if (anim != null)
                {
                    anim.SetBool("run", false);
                }

                nav.speed = walkSpeed;
            }
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
        visibleTargets.Clear();

        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, radius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            remember = false;
            Transform target = targetsInViewRadius[i].transform;
            Transform playerTargetPoint = player.transform;
            Vector3 dirToTarget = (playerTargetPoint.position - (transform.position - transform.forward)).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < currentFOVAngle / 2) 
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {               
                    spotted = true;
                    visibleTargets.Add(target);
                    lastKnownPos = playerTargetPoint.position;
                    currentFOVAngle = Mathf.Clamp(currentFOVAngle + fovSpeed * Time.deltaTime, 60f, 120f);
                    Chase();
                    Debug.Log("Spotted");                    
                }
                else
                {
                    Invoke("SetBoolFalse", 3f);

                    if (anim != null)
                    {
                        anim.SetBool("run", true);
                    }
                }
            }
            else
            {
                Invoke("SetBoolFalse", 3f);
            }
        }
    }

    void SetBoolFalse()
    {
        spotted = false;
        remember = true;
        nav.speed = walkSpeed;
        currentFOVAngle = Mathf.Clamp(currentFOVAngle - fovSpeed * Time.deltaTime, 60f, 120f);
        if (anim != null)
        {
            anim.SetBool("run", false);
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

    void Chase()
    {
        if (spotted == true)
        {
            nav.speed = runSpeed;

            if (anim != null)
            {
                anim.SetBool("run", true);
            }

            Vector3 dirToPlayer = transform.position - player.transform.position;

            Vector3 newPos = transform.position - dirToPlayer;

            nav.SetDestination(newPos);
        }
        else
        {
            nav.speed = searchSpeed;
            
            if(anim != null)
            {
                anim.SetBool("run", true);
            }

            Vector3 dirToPlayer = transform.position - lastKnownPos;

            Vector3 newPos = transform.position - dirToPlayer;

            nav.SetDestination(newPos);
        }
    }

    public void Footsteps()
    {
        FindObjectOfType<AudioManager>().Play("MonsterFootstep");
    }

    //public void Kill()
    //{
    //    nav.speed = 0;
    //}
}