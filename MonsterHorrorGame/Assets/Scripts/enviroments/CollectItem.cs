using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
  [SerializeField]
  private Player plr = null;
  [SerializeField]
  private GameObject staminaBox = null;





    // Start is called before the first frame update
    void Start()
    {

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
      Destroy(staminaBox);
    }

}
