using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorOpen : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private bool unlocked = true;

    private bool beep = false;

    private bool open = false;

    //[SerializeField]
    //private AudioSource openAudio = null;
    //[SerializeField]
    //private AudioSource beepAudio = null;
    //[SerializeField]
    //private AudioSource brrrrAudio = null;


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

        if (unlocked)
        {
          if (open)
          {
            //anim.SetTrigger("opendoor");
          }
          else
          {

          }
                    
        }
        else
        {
          FindObjectOfType<AudioManager>().Play("Door-Brrr");
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

      FindObjectOfType<AudioManager>().Play("Door-Whoosh");

    }






}
