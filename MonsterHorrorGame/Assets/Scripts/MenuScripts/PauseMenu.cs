using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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

    //Control info Page
    [SerializeField]
    private GameObject ctrlInfo = null;

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
    private GameObject winText = null;

    [SerializeField]
    private GameObject falldeathText = null;
    [SerializeField]
    private GameObject fallUI = null;

    //collection popup confirms:
    [SerializeField]
    private Text collectedItemText = null;
    [SerializeField]
    private GameObject torchIcon = null;
    [SerializeField]
    private GameObject blueCardIcon = null;
    [SerializeField]
    private GameObject purpleCardIcon = null;
    [SerializeField]
    private GameObject greenCardIcon = null;
    [SerializeField]
    private GameObject keyIcon = null;
    [SerializeField]
    private GameObject staminaIcon = null;

    private bool firstpickup = false;
    [SerializeField]
    private GameObject tabexplain = null;
    [SerializeField]
    private Text explainText = null;
    //[SerializeField]
    //private Text staminaNumberText = "x0";
    [SerializeField]
    private GameObject collectScreen = null;

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
        ctrlInfo.SetActive(false);
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

    public void ControlInfoON()
    {
        FindObjectOfType<AudioManager>().Play("UI-Click");
        ctrlInfo.SetActive(true);
        pauseMenu.SetActive(false);

    }
    public void ControlInfoOFF()
    {
        FindObjectOfType<AudioManager>().Play("UI-Click");
        ctrlInfo.SetActive(false); 
        pauseMenu.SetActive(true);
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

      //confimation Pickups:

      public void TorchCollect()
      {
        collectScreen.SetActive(true);
        collectedItemText.text = "torch";
        torchIcon.SetActive(true);
        InvenExplain();
        StartCoroutine(IconOff());
      }

    private void InvenExplain()
    {
        if(firstpickup == false)
        {
            tabexplain.SetActive(true);
            explainText.text = "Press TAB for Inventory";
            firstpickup = true;
        }
    }

      public void StaminaCollect()
      {
        collectScreen.SetActive(true);
        collectedItemText.text = "Stamina";
        staminaIcon.SetActive(true);
        StaminaExplain();
        //staminaNumberText.text = "";
        StartCoroutine(IconOff());
      }

    private void StaminaExplain()
    {
        tabexplain.SetActive(true);
        explainText.text = "Press Q to use Stamina";
    }

    public void BlueCardCollect()
    {
        collectScreen.SetActive(true);
        collectedItemText.text = "Blue Keycard";
        blueCardIcon.SetActive(true);
        InvenExplain();
        StartCoroutine(IconOff());
    }
    public void PurpleCardCollect()
    {
        collectScreen.SetActive(true);
        collectedItemText.text = "Purple Keycard";
        purpleCardIcon.SetActive(true);
        StartCoroutine(IconOff());
    }
    public void GreenCardCollect()
    {
        collectScreen.SetActive(true);
        collectedItemText.text = "Green Keycard";
        greenCardIcon.SetActive(true);
        StartCoroutine(IconOff());
    }
    public void KeyCollect()
    {
        collectScreen.SetActive(true);
        collectedItemText.text = "Key";
        keyIcon.SetActive(true);
        StartCoroutine(IconOff());
    }



    IEnumerator IconOff()
    {
        yield return new WaitForSeconds(1.5f);
        collectScreen.SetActive(false);
        torchIcon.SetActive(false);
        blueCardIcon.SetActive(false);
        purpleCardIcon.SetActive(false);
        greenCardIcon.SetActive(false);
        keyIcon.SetActive(false);
        staminaIcon.SetActive(false);
        tabexplain.SetActive(false);
    }



    //wining the game
    public void WinGame()
    {
        StartCoroutine(Winning());

    }

    IEnumerator Winning()
    {
        black.SetActive(true);
        winText.SetActive(true);
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Game");
        yield return new WaitForSeconds(2f);
        winText.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        winPage.SetActive(true);
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
