using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard : MonoBehaviour
{

    //lab room doors (tube of goo room)
    [SerializeField]
    private DoorOpen door1;
    [SerializeField]
    private DoorOpen door2;
    [SerializeField]
    private DoorOpen door3;

    //the Hud Icon:
    [SerializeField]
    private GameObject cardIcon = null;

    //the KeyCard Object
    [SerializeField]
    private GameObject keyCard = null;


    private void Start()
    {
        cardIcon.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        UnlockDoors();
        CollectCard();
    }

    private void CollectCard()
    {
        cardIcon.SetActive(true);
        Destroy(keyCard);
    }


    private void UnlockDoors()
    {
        door1.UnLock();
        door2.UnLock();
        door3.UnLock();
    }

    

}
