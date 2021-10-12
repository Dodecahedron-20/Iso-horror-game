using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLight : MonoBehaviour
{
    [SerializeField]
    private GameObject interactIcon = null;
    private bool interact = false;

    [SerializeField]
    private GameObject computerLightsMenu = null;
    private bool active = false;

    //the list of affected lights:
    [SerializeField]
    private GameObject lights = null;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interact == true)
        {
            if (active == false)
            {
                FindObjectOfType<AudioManager>().Play("UI-Click");
                interactIcon.SetActive(false);
                //interact = false;
                computerLightsMenu.SetActive(true);
                active = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                LightsDone();
            }         
        }
        if ((Input.GetKey(KeyCode.Escape)) || (Input.GetKey(KeyCode.Tab)) || (Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.D)))
        {
            if (active == true)
            {
                LightsDone();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            interact = true;
            interactIcon.SetActive(true);
            //StartCoroutine(Timer());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interactIcon.SetActive(false);
            interact = false;
        }
    }

    //IEnumerator Timer()
    //{

    //    yield return new WaitForSeconds(0.5f);
    //    if (active == false)
    //    {
    //        interactIcon.SetActive(false);
    //        interact = false;
    //    }
    //}

    //on screen buttons:

    public void LightsDone()
    {
        FindObjectOfType<AudioManager>().Play("UI-Click");
        computerLightsMenu.SetActive(false);
        active = false;
        Cursor.lockState = CursorLockMode.Locked;
        interact = false;
    }

    public void LightsOn()
    {
        FindObjectOfType<AudioManager>().Play("UI-Click");
        lights.SetActive(true);
    }

    public void LightsOff()
    {
        FindObjectOfType<AudioManager>().Play("UI-Click");
        lights.SetActive(false);
    }

}
