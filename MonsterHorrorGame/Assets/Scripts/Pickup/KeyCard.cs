using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameAnalyticsSDK;

public class KeyCard : MonoBehaviour
{

    //linked doors:
    [SerializeField]
    private DoorOpen door1;
    [SerializeField]
    private DoorOpen door2;
    [SerializeField]
    private DoorOpen door3;

    //the Hud Icon:
    [SerializeField]
    private GameObject cardIcon = null;

    [SerializeField]
    private GameObject interactIcon = null;

    //analytics sting name:
    //[SerializeField]
    //private String name;
    //??????????

    //the KeyCard Object
    [SerializeField]
    private GameObject keyCard = null;

    private bool item = false;

    //the specific card:
    [SerializeField] bool blue = false;
    [SerializeField] bool green = false;
    [SerializeField] bool purple = false;

    [SerializeField]
    private PauseMenu pm;

    private void Start()
    {
        cardIcon.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && item == true)
        {
            UnlockDoors();
            CollectCard();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            item = true;
            interactIcon.SetActive(true);
            //StartCoroutine(Timer());
        }
    }

    private void CollectCard()
    {
        cardIcon.SetActive(true);
        interactIcon.SetActive(false);
        item = false;
        if(blue)
        {
            pm.BlueCardCollect();
            GameAnalytics.NewDesignEvent("BlueCard");
        }
        if (green)
        {
            pm.GreenCardCollect();
            GameAnalytics.NewDesignEvent("GreenCard");
        }
        if(purple)
        {
            pm.PurpleCardCollect();
            GameAnalytics.NewDesignEvent("PurpleCard");
        }
        //GameAnalytics.NewDesignEvent(name);
        Destroy(keyCard);
    }

    //set doors to unlocked
    private void UnlockDoors()
    {
        door1.UnLock();
        door2.UnLock();
        door3.UnLock();
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interactIcon.SetActive(false);
            item = false;
        }
    }

    //IEnumerator Timer()
    //{
    //    yield return new WaitForSeconds(2f);
    //    interactIcon.SetActive(false);
    //    item = false;
    //}

}
