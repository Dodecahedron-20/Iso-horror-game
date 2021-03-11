using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDirector : MonoBehaviour
{
    public Monster monster;

    [SerializeField] float startTimer;
    [SerializeField] float timeSinceLastSpawn;
    [SerializeField] float playerDistance;

    void Update()
    {

    }
}
