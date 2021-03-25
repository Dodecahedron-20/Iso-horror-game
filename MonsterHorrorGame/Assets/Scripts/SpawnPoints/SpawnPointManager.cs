using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointManager : MonoBehaviour
{
    public Player player;
    public GameObject[] spawnPoints;
    public float minDist;

    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawnpoint");
    }

    void Update()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Debug.Log("currently assesing player distance to spawn point" + i);
            float d = Vector3.Distance(player.gameObject.transform.position, spawnPoints[i].transform.position);

            if (d < minDist)
            {
                spawnPoints[i].SetActive(false);
            }
            else 
            { 
                spawnPoints[i].SetActive(true); 
            }
        }
    }
}
