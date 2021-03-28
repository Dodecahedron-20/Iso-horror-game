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
    private bool pauseAble = true;

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

    [SerializeField]
    private GameObject falldeathText = null;
    [SerializeField]
    private GameObject fallUI = null;

    //analytics things here:
    private bool inplay = true;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;


        //StartCoroutine(GrowlsTest());
    }

    // Update is called once per frame
    void Update()
    {

      if (Input.GetKeyDown(KeyCode.Escape))
      {
        if (pauseAble == true)
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
      }

      if (Input.GetKeyDown(KeyCode.Tab)) //|| (Input.GetKeyDown(KeyCode.I))
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
            Fall();
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
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "Game-Restart");
    }

    public void Resign()
    {
      FindObjectOfType<AudioManager>().Play("UI-Click");
        SceneManager.LoadScene(0);

        if (inplay == true)
        {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "Game-Resign");
        }

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



    //wining the game
    public void WinGame()
    {
        black.SetActive(true);
        winPage.SetActive(true);
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Game");
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;

    }


  //  private void LoseGame()
   // {
      //  lost = true;
        //anim.SetBool("fadeIn", true);
       // black.SetActive(true);
       // FadeInEnd();


    //}
    //death by monster
    public void FadeInEnd()
    {
        StartCoroutine(YouDied());

    }

    IEnumerator YouDied()
    {
        youDiedText.SetActive(true);
        black.SetActive(true);
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "Game");
        yield return new WaitForSeconds(2f);
        youDiedText.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        losePage.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;

    }

    //death by falling out of the maze (somehow)

    public void Fall()
    {
        StartCoroutine(DeathByFalling());
    }

    IEnumerator DeathByFalling()
    {
        falldeathText.SetActive(true);
        black.SetActive(true);
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "Game-FallKill");

        yield return new WaitForSeconds(5f);
        falldeathText.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        fallUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
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
