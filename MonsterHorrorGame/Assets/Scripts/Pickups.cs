using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{

  [SerializeField]
  private GameObject staminaIcon = null;




    // Start is called before the first frame update
    void Start()
    {
    
        
        staminaIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

  


    public void CollectStamina()
    {
      

    }





}
