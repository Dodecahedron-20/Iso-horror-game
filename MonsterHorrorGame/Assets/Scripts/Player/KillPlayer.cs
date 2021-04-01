using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject monster;

    public GameObject pauseMenu;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        monster = GameObject.FindGameObjectWithTag("Monster");
        pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("pow");
            StartCoroutine(Kill());           
        }
    }

    IEnumerator Kill()
    {
        yield return new WaitForSeconds(0.01f);
        //player.GetComponent<Player>().moveSpeed = 0f;
        player.GetComponent<Player>().Death();
        monster.GetComponent<Monster>().nav.enabled = false;
        yield return new WaitForSeconds(0.5f);
        //animation for player death
        //animation for monster attack
        yield return new WaitForSeconds(0.5f);
        pauseMenu.GetComponent<PauseMenu>().FadeInEnd();
    }
}
