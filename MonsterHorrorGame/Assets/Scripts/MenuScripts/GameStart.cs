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
  private Text introText = null;


    // Start is called before the first frame update
    void Start()
    {
      blackground.SetActive(true);
      //StartCoroutine(Intro());




    }

    // Update is called once per frame
    void Update()
    {

    }

    //testing something dumb but fun? probably to chunky though
    IEnumerator Intro()
    {
      introText.text = "E";
      yield return new WaitForSeconds(0.2f);

      introText.text = "Em";
      yield return new WaitForSeconds(0.2f);

      introText.text = "Eme";
      yield return new WaitForSeconds(0.2f);

      introText.text = "Emer";
      yield return new WaitForSeconds(0.2f);

      introText.text = "Emere";
      yield return new WaitForSeconds(0.2f);

      introText.text = "Emereg";
      yield return new WaitForSeconds(0.2f);

      introText.text = "Emerege";
      yield return new WaitForSeconds(0.2f);

      introText.text = "Emeregen";
      yield return new WaitForSeconds(0.2f);

      introText.text = "Emeregenc";
      yield return new WaitForSeconds(0.2f);

      introText.text = "Emeregency";
      yield return new WaitForSeconds(0.2f);
    }







}
