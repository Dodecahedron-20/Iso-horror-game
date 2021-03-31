using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameAnalyticsSDK;

public class MainMenu : MonoBehaviour
{

    // in menu pages/changes:
    [SerializeField]
    private GameObject Menu = null;
    [SerializeField]
    private GameObject CreditMenu = null;
    [SerializeField]
    private GameObject InfoMenu = null;
    [SerializeField]
    private GameObject QuitPrompt = null;

    //Audio interactions
    [SerializeField]
    private AudioSource clickAudio;

    void Start()
    {
        GameAnalytics.Initialize();
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "Main Menu");
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape))
      {
        BailToMain();
      }
    }

    private void BailToMain()
    {
      clickAudio.Play();
      Menu.SetActive(true);
      CreditMenu.SetActive(false);
      InfoMenu.SetActive(false);
      QuitPrompt.SetActive(false);
    }


  //Start the Game things:
  public void StartGame()
  {
      clickAudio.Play();
      SceneManager.LoadScene(1);
      GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "Game");

  }



  //Credits Menus:
  //turn credits menu on
  public void CreditsOn()
  {
      clickAudio.Play();
      CreditMenu.SetActive(true);
      Menu.SetActive(false);
  }
  //turn credits menu off
  public void CreditsOff()
  {
       clickAudio.Play();
      CreditMenu.SetActive(false);
      Menu.SetActive(true);
  }

    //controll info???
    public void InfoOn()
    {
        clickAudio.Play();
        InfoMenu.SetActive(true);
        Menu.SetActive(false);
    }

    public void InfoOff()
    {
        clickAudio.Play();
        InfoMenu.SetActive(false);
        Menu.SetActive(true);
    }


  //Quit things:

  //when selecting the quit button bring up the Quit Yes/no option
  public void QuitPromptOn()
  {
      clickAudio.Play();
      QuitPrompt.SetActive(true);
      Menu.SetActive(false);
  }

  //selecting No and closing the quit prompt
  public void QuitPromptOff()
  {
      clickAudio.Play();
      QuitPrompt.SetActive(false);
      Menu.SetActive(true);
  }

  //selecting yes and quitting the game
  public void QuitGame()
  {
        clickAudio.Play();
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Main Menu");
        Application.Quit();
  }

}
