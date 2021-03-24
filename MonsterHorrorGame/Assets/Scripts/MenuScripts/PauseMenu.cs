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


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "Game");
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

    }

    // Pause Menu things:

    private void PauseMenuON()
    {
      if (checkinven)
      {
          InventoryOFF();
      }
        paused = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }


    private void PauseMenuOFF()
    {
        paused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    //pause Menu Buttons
    public void Resume()
    {
        PauseMenuOFF();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Resign()
    {
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
      checkinven = true;
      inventory.SetActive(true);
    }

    private void InventoryOFF()
    {
      checkinven = false;
      inventory.SetActive(false);
    }

}
