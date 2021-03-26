using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    [SerializeField]
    private PauseMenu pm;

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Player")
        {
            pm.WinGame();
        }
    }

}
