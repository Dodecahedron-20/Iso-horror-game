using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{




  //Pause Menu:
  [SerializeField]
  private GameObject pauseMenu = null;
  private bool paused = false;



    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        //analytics maze started
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

    }

    // Pause Menu things:

    private void PauseMenuON()
    {
        paused = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;


    }

    //pause Menu Buttons
    private void PauseMenuOFF()
    {
        paused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

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
        //analytics maze (lost?)
    }

}
