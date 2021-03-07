using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public GameObject Player = null;

    private NavMeshAgent nav;

    private State MyState;

    [SerializeField]
    private float PointDistance = 0;
    [SerializeField]
    private float VisionConeAngle = 0;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();

        MyState = State.WANDER;
    }

    public enum State
    {
        WANDER,
        CHASE,
        KILL
    }

    // Update is called once per frame
    void Update()
    {
        var monsterEye = transform.position + Vector3.up;
        var playerPosition = Player.transform.position + Vector3.up;
        var direction = (Player.transform.position + Vector3.up) - (transform.position + Vector3.up);
        var spotted = false;
        RaycastHit hit;

        if (Physics.Raycast(monsterEye, direction, out hit, float.PositiveInfinity))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                if (Vector3.Angle(transform.forward, direction) < VisionConeAngle)
                {
                    spotted = true;
                }
            }
            else
            {
                playerPosition = hit.point;
            }
        }

        if (spotted)
        {
            MyState = State.CHASE;
        }
        else
        {
            MyState = State.WANDER;
        }

        if (spotted)
        {
            Debug.DrawLine(monsterEye, playerPosition, Color.red);
        }
        else
        {
            Debug.DrawLine(monsterEye, playerPosition, Color.blue);
        }
    }
}
