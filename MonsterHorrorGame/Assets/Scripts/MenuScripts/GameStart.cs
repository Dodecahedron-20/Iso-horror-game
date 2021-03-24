using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
  //the script that runs a quick "loading screen"
  //to deal with the few seconds it takes to load in the player
  [SerializeField]
  private GameObject blackground = null;
  [SerializeField]
  private GameObject text = null;
  [SerializeField]
  private Text introText = null;

  [SerializeField]
  private Animator anim;



    // Start is called before the first frame update
    void Start()
    {
      blackground.SetActive(true);
      text.SetActive(true);
      StartCoroutine(Intro());




    }

    // Update is called once per frame
    void Update()
    {

    }

    //WaitForSeconds then add letter to string WORKS but like, should I really?
    IEnumerator Intro()
    {
      yield return new WaitForSeconds(2);

      TurnOff();
    }


    private void TurnOff()
    {
      
      anim.SetBool("fadeOut", true);
      text.SetActive(false);
    }





}
