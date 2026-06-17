using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int maxNum;

    public static bool spawnMinion;
    public static bool spawnTerminate;
    public static int currentNum;

    private void Start()
    {
        spawnMinion = true;
        spawnTerminate = false;
        StartCoroutine(SpawnEnemies());
    }

    private void Update()
    {
        theEnemy = GameObject.FindWithTag("Minion");

        if (spawnMinion && spawnTerminate)
        {
            EntityGlobal.spawnTerminate = false;
            StartCoroutine(SpawnEnemies());
        }
    }

    private IEnumerator SpawnEnemies()
    {
        while (spawnMinion && currentNum <= maxNum)
        {
            xPos = Random.Range(-10, 10);
            zPos = Random.Range(-10, 10);
            EntityGlobal.currentMinion++;
            Instantiate(theEnemy, new Vector3(xPos, 70, zPos), Quaternion.identity);
            yield return new WaitForSeconds(1);
        }
    }


}