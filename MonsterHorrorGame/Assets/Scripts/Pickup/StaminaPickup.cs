using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaPickup : MonoBehaviour
{
  [SerializeField]
  private Player plr = null;
  [SerializeField]
  private GameObject staminaBox = null;





    // Start is called before the first frame update
    void Start()
    {
        plr = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        //plr.RegenStamina();
        //check what method this needs to call to add back stamina.
        //also, does it give back ALL stamina, or jsut some?
        plr.currentStamina += 100;

        Destroy(staminaBox);
    }

}
