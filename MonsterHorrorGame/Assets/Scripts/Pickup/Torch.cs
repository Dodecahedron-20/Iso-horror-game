using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

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

    [SerializeField]
    private GameObject interactIcon = null;

    private bool item = false;


    // Start is called before the first frame update
    void Start()
    {
        playerLight.SetActive(false);
        torchIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && item == true)
        {
            CollectTorch();
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

    private void CollectTorch()
    {
        torchIcon.SetActive(true);
        playerLight.SetActive(true);
        interactIcon.SetActive(false);
        item = false;
        GameAnalytics.NewDesignEvent("torch");
        Destroy(torch);
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(3f);
        interactIcon.SetActive(false);
        item = false;
    }

}
