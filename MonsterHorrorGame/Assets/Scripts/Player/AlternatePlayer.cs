using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternatePlayer : MonoBehaviour
{


    private float speed;
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float sprintSpeed;



    // Start is called before the first frame update
    void Start()
    {
      speed = walkSpeed;

    }

    // Update is called once per frame
    void Update()
    {
      var horiz = 0;
      var vert = 0;


      if (Input.GetKey(KeyCode.A))
      {
        horiz += 1;
      }

      if (Input.GetKey(KeyCode.D))
      {
        horiz -= 1;
      }

      if (Input.GetKey(KeyCode.W))
      {
        vert += 1;
      }

      if (Input.GetKey(KeyCode.S))
      {
        vert -= 1;
      }

      if (Input.GetKey(KeyCode.LeftShift))
      {
        speed = sprintSpeed;
      }
      else
      {
        speed = walkSpeed;
      }

      var movement = new Vector3(vert, 0, horiz).normalized * speed * Time.deltaTime;
      transform.position += movement;


    }

    private void Sprint()
    {
      speed = sprintSpeed;
    }



}
