using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

  // in menu pages/changes:
  [SerializeField]
  private GameObject Menu = null;
  [SerializeField]
  private GameObject CreditMenu = null;
  [SerializeField]
  private GameObject QuitPrompt = null;


  //Start the Game things:
  public void StartGame()
  {
      SceneManager.LoadScene(1);
      //Game Analytics start goes here.
      //progress: Game. Started.
  }



  //Credits Menus:
  //turn credits menu on
  public void CreditsOn()
  {
      CreditMenu.SetActive(true);
      Menu.SetActive(false);
  }
  //turn credits menu off
  public void CreditsOff()
  {
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
      Application.Quit();
  }

}
