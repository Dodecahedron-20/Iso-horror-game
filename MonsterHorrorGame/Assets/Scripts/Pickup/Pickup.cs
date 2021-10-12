using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{

    [SerializeField]
    private Text confirmationText;

    [SerializeField]
    private string pickupType;


    [SerializeField]
    private GameObject interactIcon;
    private bool interact = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&& interact == true)
        {
            Collect();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interact = true;
            interactIcon.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interact = false;
            interactIcon.SetActive(false);
        }
    }

    private void Collect()
    {
        confirmationText.text = "Collected: " + pickupType;
        //HC.CollectionON();
        Result();
        Destroy(gameObject);
    }

    public virtual void Result()
    {
        //Debug.Log("things are supposed to happen here");
    }
}
