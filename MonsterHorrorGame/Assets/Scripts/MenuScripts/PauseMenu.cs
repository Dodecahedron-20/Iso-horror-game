using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameAnalyticsSDK;

public class PauseMenu : MonoBehaviour
{

//pause menu featuring the "inventory" "Menu"


    //Pause Menu:
    [SerializeField]
    private GameObject pauseMenu = null;
    private bool paused = false;

    //inventory Menu:
    [SerializeField]
    private GameObject inventory;
    private bool checkinven = false;

    //end game things:
    private bool lost = false;

    [SerializeField]
    private GameObject black;
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private GameObject winPage = null;
    [SerializeField]
    private GameObject losePage = null;
    [SerializeField]
    private GameObject youDiedText = null;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "Game");
        StartCoroutine(GrowlsTest());
    }

    // Update is called once per frame
    void Update()
    {

      if (Input.GetKeyDown(KeyCode.Escape))
      {
          if (paused == false)
          {
              PauseMenuON();
          }
          else
          {
              PauseMenuOFF();
          }

      }

      if (Input.GetKeyDown(KeyCode.E))
      {
        if (checkinven == false)
        {
          InventoryON();
        }
        else
        {
          InventoryOFF();
        }
      }
      //testing endings
      if (Input.GetKeyDown(KeyCode.G))
        {
            LoseGame();
        }

    }

    // Pause Menu things:

    private void PauseMenuON()
    {
      if (checkinven)
      {
          InventoryOFF();
      }
        FindObjectOfType<AudioManager>().Play("UI-Click");
        paused = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }


    private void PauseMenuOFF()
    {
        FindObjectOfType<AudioManager>().Play("UI-Click");
        paused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    //pause Menu Buttons
    public void Resume()
    {
      FindObjectOfType<AudioManager>().Play("UI-Click");
        PauseMenuOFF();
    }

    public void Restart()
    {
      FindObjectOfType<AudioManager>().Play("UI-Click");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Resign()
    {
      FindObjectOfType<AudioManager>().Play("UI-Click");
        SceneManager.LoadScene(0);
        //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "Game");
    }

    //inventory
    private void InventoryON()
    {
      if (paused)
      {
        PauseMenuOFF();
      }
      FindObjectOfType<AudioManager>().Play("UI-Click");
      checkinven = true;
      inventory.SetActive(true);
    }

    private void InventoryOFF()
    {
      FindObjectOfType<AudioManager>().Play("UI-Click");
      checkinven = false;
      inventory.SetActive(false);
    }


    private void LoseGame()
    {
        lost = true;
        //anim.SetBool("fadeIn", true);
        black.SetActive(true);
        FadeInEnd();


    }


    public void FadeInEnd()
    {
        StartCoroutine(YouDied());
    }

    private void WinGame()
    {

    }

    IEnumerator YouDied()
    {
        youDiedText.SetActive(true);

        yield return new WaitForSeconds(2f);
        youDiedText.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        losePage.SetActive(true);
        Cursor.lockState = CursorLockMode.None;

    }

    public void DanceOff()
    {
      FindObjectOfType<AudioManager>().Play("UI-Click");
      GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "DanceDance");
      SceneManager.LoadScene(2);
    }

IEnumerator GrowlsTest()
{
  yield return new WaitForSeconds(3f);
  FindObjectOfType<AudioManager>().Play("monsterGrowl");

  StartCoroutine(GrowlsTest());
}


}
