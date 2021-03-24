using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDirector : MonoBehaviour
{
    public Transform monster;

    [SerializeField] bool monsterActive;
    [SerializeField] float timer;
    private int randomSpawn;

    [SerializeField]
    public GameObject[] spawnPoints;

    void Start()
    {
        timer = 20f;

        spawnPoints = GameObject.FindGameObjectsWithTag("Spawnpoint");

        InvokeRepeating("CheckMonsterStatus", 3.0f, 5f);
    }

    void Update()
    {
        timer = Mathf.Clamp(timer -= Time.deltaTime, 0, 20);

        if(monster.gameObject.activeInHierarchy == true)
        {
            monsterActive = true;
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
        var player = GetComponent<Player>();

        if (timer <= 0 && monsterActive == false)
        {
            //randomSpawn = Random.Range(0, spawnPoints.Length);
            Instantiate(monster, spawnPoints[RandomSpawnPoint()].transform.position, Quaternion.identity);
            monsterActive = true;
            timer = 20f;
        }
    }

    private int RandomSpawnPoint()
    {
        int sp = 0;

        sp = Random.Range(0, spawnPoints.Length);

        if (!spawnPoints[sp].activeSelf)
        {
            sp = RandomSpawnPoint();
        }

        return sp;
    }

    void DespawnMonster()
    {
        var monster = GetComponent<Monster>();

        if (timer <= 0 && monster.spotted == false && monster.dist > 20)
        {
            Destroy(this.monster.gameObject);
            monsterActive = false;
            if(monster != null)
            {
                timer = 20f;
            }          
        }
    }
}
