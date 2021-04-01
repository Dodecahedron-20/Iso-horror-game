using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
  //the script that runs a quick "loading screen"
  //to deal with the few seconds it takes to load in the player
  [SerializeField]
  GameObject intro = null;
  [SerializeField]
  private GameObject blackground = null;
  [SerializeField]
  private GameObject text = null;
  [SerializeField]
  private Text introText = null;

  [SerializeField]
  private Animator anim;

    [SerializeField]
    private MiscAudio msc;

    [SerializeField]
    private PauseMenu pm;



    // Start is called before the first frame update
    void Start()
    {
      blackground.SetActive(true);
      text.SetActive(true);
      StartCoroutine(Intro());
        //FindObjectOfType<AudioManager>().Play("Siren1");



    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
        intro.SetActive(false);

      }

    }

    //WaitForSeconds then add letter to string WORKS but like, should I really?
    IEnumerator Intro()
    {
      yield return new WaitForSeconds(0.8f);
      text.SetActive(false);

      yield return new WaitForSeconds(0.2f);
      text.SetActive(true);

      yield return new WaitForSeconds(0.4f);
      text.SetActive(false);

      yield return new WaitForSeconds(0.2f);
      text.SetActive(true);

      yield return new WaitForSeconds(0.4f);
      text.SetActive(false);

      yield return new WaitForSeconds(0.2f);
      anim.SetBool("fadeOut", true);
      msc.StartWind();

    }







}
