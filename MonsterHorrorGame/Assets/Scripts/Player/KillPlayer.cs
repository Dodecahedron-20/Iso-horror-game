using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public Player player;
    public Monster monster;
    public float damage;

    [SerializeField]
    PauseMenu pm;

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
        yield return new WaitForSeconds(0.5f);
        //animation for player death
        //animation for monster attack
        yield return new WaitForSeconds(0.5f);
        pm.FadeInEnd();

    }

}
