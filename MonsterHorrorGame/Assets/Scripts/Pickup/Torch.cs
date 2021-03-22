using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{


    //torch item:
    [SerializeField]
    private GameObject torch = null;

    //light on player:
    [SerializeField]
    private GameObject playerLight = null;

    //UI Icon
    [SerializeField]
    private GameObject torchIcon = null;

    // Start is called before the first frame update
    void Start()
    {
        playerLight.SetActive(false);
        torchIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        torchIcon.SetActive(true);
        playerLight.SetActive(true);
        //game analytics collected torch
        Destroy(torch);
    }




}
