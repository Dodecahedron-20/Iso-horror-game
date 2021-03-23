using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDirector : MonoBehaviour
{
    public Transform monster;

    [SerializeField] bool monsterActive;
    [SerializeField] float timer;

    [SerializeField]
    public GameObject[] spawnPoints;

    void Start()
    {
        timer = 20f;

        spawnPoints = GameObject.FindGameObjectsWithTag("Waypoint");

        //StartCoroutine(CheckMonsterStatus());
    }

    void Update()
    {
        timer = Mathf.Clamp(timer -= Time.deltaTime, 0, 20);

        if(monster.gameObject.activeInHierarchy == true)
        {
            monsterActive = true;
        }

        if(timer <=0)
        {
            CheckMonsterStatus();
        } 
    }

    void CheckMonsterStatus()
    {
        if (monsterActive == false)
        {
            SpawnMonster();
        }

        if (monsterActive == true)
        {
            DespawnMonster();
        }
    }

    void SpawnMonster()
    {
        if (timer <= 0 && monsterActive == false)
        {
            monster.gameObject.SetActive(true);
            monsterActive = true;
            timer = 20f;
        }
    }

    void DespawnMonster()
    {
        var monster = GetComponent<Monster>();

        if (timer <= 0 && monster.spotted == false && monster.dist > 20)
        {
            Destroy(this.monster.gameObject);
            monsterActive = false;
            if(monster == null)
            {
                timer = 20f;
            }          
        }
    }
}
