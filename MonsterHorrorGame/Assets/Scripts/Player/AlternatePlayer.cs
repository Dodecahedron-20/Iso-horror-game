using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternatePlayer : MonoBehaviour
{

    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {

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

      var movement = new Vector3(horiz, 0, vert).normalized * speed * Time.deltaTime;
      transform.position += movement;


    }





}
