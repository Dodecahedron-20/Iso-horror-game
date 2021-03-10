using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countdown : MonoBehaviour
{
//the script to run counting for spawning in the monster periodicaly

  private int seconds = 0;
  private int countTime = 20;

  private bool monsterInPlay = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartCount()
    {
      StartCoroutine(CountingSeconds());

    }


    IEnumerator CountingSeconds()
    {
      if (seconds > 0)
      {
        //double check this code here:
        yield return new WaitForSeconds(1);
        seconds --;

      }
      else if (monsterInPlay == false)
      {
        //spawn monster script thing goes here.
       monsterInPlay = true;
      }



    }


    private void NewCount()
    {




      seconds = countTime;


    }

}
