using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDirector : MonoBehaviour
{
    public Transform monster;

    [SerializeField] bool monsterActive;
    [SerializeField] float timer;

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
            this.monster.gameObject.SetActive(false);
            monsterActive = false;
            timer = 20f;
        }
    }
}
