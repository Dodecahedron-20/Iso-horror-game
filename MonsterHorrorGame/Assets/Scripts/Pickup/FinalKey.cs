using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class FinalKey : MonoBehaviour
{

    //Key itself
    [SerializeField]
    private GameObject key = null;

    [SerializeField]
    private GameObject keyIcon = null;

    [SerializeField]
    private GameObject interactIcon = null;

    [SerializeField]
    private DoorOpen door;

    private bool item = false;

    [SerializeField]
    private PauseMenu pm;

    // Start is called before the first frame update
    void Start()
    {
        keyIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && item == true)
        {
            CollectKey();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            item = true;
            interactIcon.SetActive(true);
            //StartCoroutine(Timer());
        }
    }

    private void CollectKey()
    {
        door.UnLock();
        keyIcon.SetActive(true);
        interactIcon.SetActive(false);
        pm.KeyCollect();
        GameAnalytics.NewDesignEvent("Key");
        Destroy(key);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interactIcon.SetActive(false);
            item = false;
        }
    }

    //IEnumerator Timer()
    //{
    //    yield return new WaitForSeconds(3f);
    //    interactIcon.SetActive(false);
    //    item = false;
    //}
}
