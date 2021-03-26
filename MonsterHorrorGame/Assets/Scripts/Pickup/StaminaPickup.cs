using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaPickup : MonoBehaviour
{
    public Player player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PickUp();
        }
    }

    void PickUp()
    {
        player.currentStamina += 100f;

        Destroy(gameObject);
    }
}
