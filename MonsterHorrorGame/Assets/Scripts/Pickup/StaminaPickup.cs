using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaPickup : MonoBehaviour
{
    public Player player;

    private bool item = false;

    [SerializeField]
    private GameObject interactIcon = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && item == true)
        {
            PickUp();
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

    void PickUp()
    {
        
        interactIcon.SetActive(false);
        item = false;
        player.StaminaRegen();
        Destroy(gameObject);
    }


    IEnumerator Timer()
    {
        yield return new WaitForSeconds(10f);
        interactIcon.SetActive(false);
        item = false;
    }
}
