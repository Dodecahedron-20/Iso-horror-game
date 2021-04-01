using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            StartCoroutine(Timer());
        }
    }

    private void CollectCard()
    {
        cardIcon.SetActive(true);
        interactIcon.SetActive(false);
        item = false;
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


    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2f);
        interactIcon.SetActive(false);
        item = false;
    }

}
