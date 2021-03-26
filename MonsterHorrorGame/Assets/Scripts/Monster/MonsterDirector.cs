using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDirector : MonoBehaviour
{
    public Transform monsterPrefab;
    public Transform monsterClone;

    [SerializeField] bool monsterActive;
    public float timer;

    [SerializeField]
    public GameObject[] spawnPoints;

    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawnpoint");

        InvokeRepeating("CheckMonsterStatus", 3.0f, 5f);

        StartCoroutine(DisableBool(5f));
    }

    void Update()
    {
        timer = Mathf.Clamp(timer -= Time.deltaTime, 0, 50);

        if(monsterClone != null)
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
            monsterClone = Instantiate(monsterPrefab.gameObject, spawnPoints[RandomSpawnPoint()].transform.position, Quaternion.identity).transform;
            monsterActive = true;
            timer = 50f;
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
        Monster monster = monsterClone.GetComponent<Monster>();

        if (timer <= 0 && monster.spotted != true && monster.dist > 10)
        {
            Destroy(this.monsterClone.gameObject);
            monsterActive = false;
            if(monster != null)
            {
                timer = 50f;
            }          
        }
    }

    IEnumerator DisableBool(float delay)
    {
        while(true)
        {
            yield return new WaitForSeconds(delay);
            MonsterForget();
        }
    }

    void MonsterForget()
    {
        Monster monster = monsterClone.GetComponent<Monster>();

        bool remember = monsterClone.GetComponent<Monster>().remember;

        if (remember == true && monster.dist > 5)
        {
            monster.remember = false;
        }
    }
}
