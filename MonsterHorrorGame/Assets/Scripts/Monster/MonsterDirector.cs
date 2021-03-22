using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDirector : MonoBehaviour
{
    public Transform monster;

    [SerializeField] bool monsterActive;
    [SerializeField] float timer;
    [SerializeField] float timeSinceLastSpawn;
    [SerializeField] float playerDistance;

    public List<Waypoint> spawnPoints;

    void Start()
    {       
        monsterActive = false;

        //StartCoroutine(CheckMonsterStatus());
    }

    void Update()
    {
        timer = Mathf.Clamp(timer -= Time.deltaTime, 0, 20);

        if(timer <=0)
        {
            CheckMonsterStatus();
        }
    }

    void CheckMonsterStatus()
    {
        if (monster == false)
        {
            SpawnMonster();
        }

        if (monster == true)
        {
            DespawnMonster();
        }
    }

    void SpawnMonster()
    {
        if (timer <= 0)
        {
            monster.gameObject.SetActive(true);
            monsterActive = true;
            timer = 20f;
        }
    }

    void DespawnMonster()
    {
        var monster = GetComponent<Monster>();

        timer = Mathf.Clamp(timer -= Time.deltaTime, 0, 20);

        if (timer <= 0 && monster.spotted == false && monster.dist > 20)
        {
            monster.gameObject.SetActive(false);
            monsterActive = false;
            timer = 20f;
        }
    }
}
