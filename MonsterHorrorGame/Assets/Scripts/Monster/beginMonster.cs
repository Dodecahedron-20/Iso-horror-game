using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beginMonster : MonoBehaviour
{
    [SerializeField]
    private GameObject monCtrl = null;
    [SerializeField]
    private GameObject item = null;

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
        monCtrl.SetActive(true);
        Destroy(item);
    }

}
