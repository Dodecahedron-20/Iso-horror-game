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
  private GameObject QuitPrompt = null;
    //Audio interactions
    [SerializeField]
    private AudioSource clickAudio = null;

  //Start the Game things:
  public void StartGame()
  {
      SceneManager.LoadScene(1);
      GameAnalytics.Initialize();
      GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "Main Menu");
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



  //Quit things:

  //when selecting the quit button bring up the Quit Yes/no option
  public void QuitPromptOn()
  {

      QuitPrompt.SetActive(true);
      Menu.SetActive(false);
  }

  //selecting No and closing the quit prompt
  public void QuitPromptOff()
  {
      QuitPrompt.SetActive(false);
      Menu.SetActive(true);
  }

  //selecting yes and quitting the game
  public void QuitGame()
  {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Main Menu");
        Application.Quit();
  }

}
