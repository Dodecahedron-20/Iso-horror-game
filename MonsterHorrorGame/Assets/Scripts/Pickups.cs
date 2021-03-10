using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
  [SerializeFeild]
  private GameObject torchIcon = null;
  [SerializeFeild]
  private GameObject cardIcon = null;
  [SerializeFeild]
  private GameObject keyIcon = null;
  [SerializeFeild]
  private GameObject staminaIcon = null;




    // Start is called before the first frame update
    void Start()
    {
        torchIcon.SetActive(false);
        cardIcon.SetActive(false);
        keyIcon.SetActive(false);
        staminaIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CollectTorch()
    {
      torchIcon.SetActive(true);
    }

    public void CollectCard()
    {
      cardIcon.SetActive(true);
    }

    public void CollectKey()
    {
      keyIcon.SetActive(true);
    }

    public void CollectStamina()
    {
      

    }





}
