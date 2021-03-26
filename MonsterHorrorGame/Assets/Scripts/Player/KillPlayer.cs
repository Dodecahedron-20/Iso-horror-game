using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public Player player;
    public Monster monster;
    public float damage;

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            Debug.Log("pow");
            StartCoroutine(Kill());           
        }
    }

    IEnumerator Kill()
    {
        yield return new WaitForSeconds(0.1f);
        player = GetComponent<Player>();
        monster = GetComponent<Monster>();
        player.moveSpeed = 0f;
        monster.nav.speed = 0f;

        player.gameObject.GetComponent<Player>().health -= damage;
    }

}
