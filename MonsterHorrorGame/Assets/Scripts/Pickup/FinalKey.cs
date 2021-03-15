using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalKey : MonoBehaviour
{

    //Key itself
    [SerializeField]
    private GameObject key = null;

    //the final door
    // [SerializeField]
    //private (something) endDoor;

    [SerializeField]
    private GameObject keyIcon = null;

    // Start is called before the first frame update
    void Start()
    {
        keyIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        CollectKey();
    }

    private void CollectKey()
    {
        keyIcon.SetActive(true);
        Destroy(key);
    }
}
