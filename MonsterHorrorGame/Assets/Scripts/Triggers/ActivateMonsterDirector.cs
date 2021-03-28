using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMonsterDirector : MonoBehaviour
{
    public GameObject monsterDirector;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            monsterDirector.SetActive(true);
            Destroy(gameObject);
        }
    }
}
