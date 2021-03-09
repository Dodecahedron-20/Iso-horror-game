using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;

public class Monster : MonoBehaviour
{
    public Transform player;

    [SerializeField] bool spotted;
    [SerializeField] float fovAngle;
    [SerializeField] float range;
    [SerializeField] float speed;
    [SerializeField] float chaseSpeed;

    public Transform[] patrolWayPoints;
    [Range(0, 360)]
    [SerializeField] float eyeHeight = 3.65f;


    [SerializeField] private Vector3 lastKnownPos;
    [SerializeField] Color sightColour = new Color(207, 169, 255, 255);

    private NavMeshAgent nav;

    Rigidbody rb;

    RaycastHit hit;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Look();
    }

    void Look()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range);

        foreach (var Player in hitColliders)
        {
            if (Player.gameObject.tag == "Player")
            {
                Debug.Log("Detected");
            }
            else
            {
                Debug.Log("Not Detected");
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

    #region Helper Classes
    public Vector3 DirectionFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.rotation.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
    #endregion

#if UNITY_EDITOR

    private void OnDrawGizmosSelected()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, range);

        Vector3 eyePos = transform.position;
        eyePos.y += eyeHeight;

        Gizmos.color = sightColour;
        //Gizmos.DrawWireSphere(eyePos, sightRange);
        Handles.color = sightColour;
        Handles.DrawWireArc(eyePos - transform.forward, Vector3.up, Vector3.forward, 360, range);
        Vector3 viewAngleA = DirectionFromAngle(-fovAngle / 2, false);
        Vector3 viewAngleB = DirectionFromAngle(fovAngle / 2, false);
        Handles.DrawLine(eyePos - transform.forward, eyePos - transform.forward + viewAngleA * range);
        Handles.DrawLine(eyePos - transform.forward, eyePos - transform.forward + viewAngleB * range);

        //Handles.color = Color.red;
        //if (playerTracker.Count > 0)
        //{
        //    Handles.DrawLine(eyePos, playerTracker[0].position);
        //}
    }

#endif
}
