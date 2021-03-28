using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorOpen : MonoBehaviour
{
    [SerializeField] Animator anim;

    [SerializeField] bool unlocked;

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
            if (unlocked == true)
            {
              if (open == false)
              {
                anim.SetTrigger("opendoor");
                open = true;
                StartCoroutine(TimeToClose());
              }
              else
              {
                anim.SetTrigger("closedoor");
                open = false;
              }

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

        FindObjectOfType<AudioManager>().Play("Door-Whoosh");
    }

    IEnumerator TimeToClose()
    {
      yield return new WaitForSeconds(2f);
      if (open)
      {
        anim.SetTrigger("closedoor");
        open = false;
      }
    }
}
