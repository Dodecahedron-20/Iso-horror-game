﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorOpen : MonoBehaviour
{
    [SerializeField]
    private Animator anim;


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
        anim.SetTrigger("opendoor");

    }



}
