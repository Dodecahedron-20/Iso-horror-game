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
      if (mon == false)
      {
        yield return new WaitForSeconds(23.5f);
        FindObjectOfType<AudioManager>().Play("monsterGrowl");

        //yield return new WaitForSeconds(30f);
        //FindObjectOfType<AudioManager>().Play("monsterGrowl");

        StartCoroutine(Growls());
      }
    }

    //Goo Lab Audio:

    private void OnTriggerEnter(Collider other)
    {
      if (lab == false)
      {
        lab = true;
      }
      else
      {
        lab = false;
      }

    }

    //does this need to be it's own method???
    //probably not?
    IEnumerator LabAudio()
    {
      if (lab)
      {
        //FindObjectOfType<AudioManager>().Play("goo-bubbles");
        yield return new WaitForSeconds(goo);



        StartCoroutine(LabAudio());
      }
    }








}
