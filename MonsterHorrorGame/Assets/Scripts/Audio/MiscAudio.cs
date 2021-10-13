using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscAudio : MonoBehaviour
{

    //growls sparodic:
    private bool mon = false;


    //lab-goo bubbles:
    private bool lab = false;
    private float goo = 5;




    //"wind whistle":
    public void StartWind()
    {
        FindObjectOfType<AudioManager>().Play("wind-whistle");
        FindObjectOfType<AudioManager>().Play("abientHorror");
        Growls();
    }

    public void MonsterSwitch()
    {
      if (mon == false)
      {
        mon = true;
      }
      else
      {
        mon = false;
      }
    }


    IEnumerator Growls()
    {
      if (mon)
      {
        yield return new WaitForSeconds(8f);
        FindObjectOfType<AudioManager>().Play("monsterGrowl");

        yield return new WaitForSeconds(13f);
        FindObjectOfType<AudioManager>().Play("monsterGrowl");

        StartCoroutine(Growls());
      }
    }

    //Goo Lab Audio:

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && lab == false)
        {
            lab = true;
            StartCoroutine(LabAudio());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            lab = false;
        }
    }

    //does this need to be it's own method???
    //probably not?
    IEnumerator LabAudio()
    {
        if (lab == true)
        {
            FindObjectOfType<AudioManager>().Play("bubble1");
             yield return new WaitForSeconds(0.8f);

            FindObjectOfType<AudioManager>().Play("bubble2");
            yield return new WaitForSeconds(0.3f);

            FindObjectOfType<AudioManager>().Play("bubble3");
            yield return new WaitForSeconds(0.5f);

            StartCoroutine(LabAudio());
        }
    }








}
