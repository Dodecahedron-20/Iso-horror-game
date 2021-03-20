using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDirector : MonoBehaviour
{
    public Monster monster;

    [SerializeField] bool monsterActive;
    [SerializeField] float startTimer;
    [SerializeField] float timeSinceLastSpawn;
    [SerializeField] float playerDistance;
    
    public List<Waypoint> spawnPoints;

    void Start()
    {
        monsterActive = false;

        StartCoroutine(CheckMonsterStatus());
    }

    void Update()
    {

    }

    IEnumerator CheckMonsterStatus()
    {
        yield return new WaitForSeconds(5f);
        if(startTimer <= 0 && timeSinceLastSpawn > 5)
        {
            monsterActive = true;
        }
    }
}
