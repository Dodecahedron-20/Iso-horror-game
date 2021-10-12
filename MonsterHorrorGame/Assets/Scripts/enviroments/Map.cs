using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    [SerializeField]
    private GameObject interactIcon = null;
    private bool interact = false;


    [SerializeField]
    private GameObject computerMapMenu = null;
    [SerializeField]
    private GameObject warning = null;

    [SerializeField]
    private GameObject fullmap = null;
    [SerializeField]
    private GameObject zoomMap = null;


    private bool active = false;

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
                computerMapMenu.SetActive(true);
                warning.SetActive(true);
                fullmap.SetActive(true);
                zoomMap.SetActive(false);
                StartCoroutine(WarningOff());
                active = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                MapDone();
            }
        }
        if ((Input.GetKey(KeyCode.Escape)) || (Input.GetKey(KeyCode.Tab)) || (Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.D)))
        {
            if (active == true)
            {
                MapDone();
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

    //    yield return new WaitForSeconds(2f);
    //    if (active == false)
    //    {
    //        interactIcon.SetActive(false);
    //        interact = false;
    //    }
    //}

    IEnumerator WarningOff()
    {
        yield return new WaitForSeconds(0.2f);
        warning.SetActive(false);
    }

    public void CloseupMapON()
    {
        FindObjectOfType<AudioManager>().Play("UI-Click");
        fullmap.SetActive(false);
        zoomMap.SetActive(true);
    }

    public void CloseupMapOFF()
    {
        FindObjectOfType<AudioManager>().Play("UI-Click");
        fullmap.SetActive(true);
        zoomMap.SetActive(false);
    }


    public void MapDone()
    {
        FindObjectOfType<AudioManager>().Play("UI-Click");
        computerMapMenu.SetActive(false);
        active = false;
        Cursor.lockState = CursorLockMode.Locked;
        interact = false;
    }


}
