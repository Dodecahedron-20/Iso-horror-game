using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorOpen : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private bool active = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (active)
        {
            anim.SetTrigger("opendoor");
        }
        

    }

    private void SetActive()
    {
        active = true;
    }



}
