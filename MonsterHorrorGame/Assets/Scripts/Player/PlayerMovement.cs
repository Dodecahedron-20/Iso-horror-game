using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("W"))
        {
            rb.AddForce(0, 0, speed * Time.deltaTime);
        }

        if(Input.GetKey("S"))
        {
            rb.AddForce(0, 0, -speed * Time.deltaTime);
        }

        if(Input.GetKey("A"))
        {
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        }

        if(Input.GetKey("D"))
        {
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }
    }
}
