using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DanceDance : MonoBehaviour
{
  //script goes on dancing monster

//the fade in/out Animator
  [SerializeField]
  private Animator anim;

  [SerializeField]
  private Animator monsterAnim;

  [SerializeField]
  private GameObject black;



    // Start is called before the first frame update
    void Start()
    {
      monsterAnim.SetBool("dance", true);

    }

    // Update is called once per frame
    void Update()
    {
      //could make anyKey instead for like, if you hit a key the scene dissolves?
      if (Input.GetKeyDown(KeyCode.Escape))
      {
        MainMenu();
      }

    }

    IEnumerator FadeOut()
    {
      yield return new WaitForSeconds(1f);
      anim.SetBool("fadeOut", true);
      StartCoroutine(DanceDanceBaby());
    }



    IEnumerator DanceDanceBaby()
    {
      //check time for like, two loops of dancing monster.
      yield return new WaitForSeconds(10f);

      MainMenu();
    }

    public void MainMenu()
    {
      StartCoroutine(Leave());
    }

    IEnumerator Leave()
    {
      black.SetActive(true);
      anim.SetBool("fadeIn", true);

      //check fade time
      yield return new WaitForSeconds(2f);

      SceneManager.LoadScene(0);
    }




}
