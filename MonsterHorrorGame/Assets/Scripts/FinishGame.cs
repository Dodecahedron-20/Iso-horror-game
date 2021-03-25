using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    public TextMeshProUGUI youWinText;

    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.tag == "Player")
        {
            StartCoroutine(GameWin());
        }
    }

    IEnumerator GameWin()
    {
        yield return new WaitForSeconds(0.5f);
        youWinText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("GameScene");
    }
}
