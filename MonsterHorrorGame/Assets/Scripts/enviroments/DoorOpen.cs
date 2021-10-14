using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorOpen : MonoBehaviour
{
    [SerializeField] Animator anim;

    [SerializeField] bool unlocked;

    [SerializeField] AudioSource whoosh;


    bool beep = false;
    bool open = false;

    //[SerializeField]
    //private AudioSource openAudio = null;
    //[SerializeField]
    //private AudioSource beepAudio = null;
    //[SerializeField]
    //private AudioSource brrrrAudio = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Monster")
        {
            if (unlocked == true || other.gameObject.tag == "Monster")
            {
                anim.SetTrigger("opendoor");
                open = true;                     
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("Door-Brrr");
            }
        }
    }

    public void UnLock()
    {
        unlocked = true;
        beep = true;
    }

    //audio goes here:
    public void OpenAudio()
    {
        //if (beep == true)
        //{
        //beepAudio.Play();
        //}
        whoosh.Play();
        //FindObjectOfType<AudioManager>().Play("Door-Whoosh");

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Monster")
        {
            if (open)
            {
                anim.SetTrigger("closedoor");
                open = false;
            }
        }
    }

}
