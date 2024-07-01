using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{

    public Transform[] SpawnPoints = new Transform[8];
    public GameObject[] enemyTypes = new GameObject[8];
    public List<GameObject> enemies = new List<GameObject>();

    public GameObject player;


    float spawnDelay = 3;

    void Start()
    {
       for(int i = 0; i < 101; i++)
        {
            print (i);
        }
        SpawnEnemy();    
    }


    private void start ()
    {
        GameEvents.EnemyDie += EnemyDied;
        ShuffleList(enemies);
    }


    private void OnDestroy()
    {
        GameEvents.EnemyDie -= EnemyDied;
    }



    void SpawnEnemy ()
    {
        for (int i = 0; i < SpawnPoints.Length; i++)
        {
            int rNull = Random.Range(0, enemyTypes.Length);
            GameObject enemy = Instantiate(enemyTypes[0], SpawnPoints[i].position, SpawnPoints[i].rotation);
            enemies.Add(enemy);
        }
        print("enemy Count: " + enemies.Count);
    }


    void SumFirst10NaturalNumbers()
    {
        int sum = 0;
            for (int i = 1; i < 11; i++)
            sum += i;
            Debug.Log(sum);
    }

    void SumNaturalNumbers(int targetNums)
    {
        int sum = 0;
        for (int i = 1; i < targetNums + 1; i++) 
            sum+= i;   
        Debug.Log(sum);
    }

    GameObject FindClosestEnemyTopPlayer()
    {
        GameObject closestEnemy = null;
        float bestDistance = float.MaxValue;

        for (int i = 0; i < enemies.Count; i++)
        {
            float distance = Vector3.Distance(player.transform.position, enemies[i].transform.position);
            if (distance < bestDistance)
            {
                bestDistance = distance;
                closestEnemy = enemies[i];
            }
        }
        return closestEnemy;
    }


    IEnumerator SpawnEnemyDelayed()
    {
        for (int i = 0; i < SpawnPoints.Length; i++)
        {
            int rndEnemy = Random.Range(0, enemyTypes.Length);
            GameObject enemy = Instantiate(enemyTypes[rndEnemy], SpawnPoints[i].position, SpawnPoints[i].rotation);
            enemies.Add(enemy);
            yield return new WaitForSeconds(spawnDelay);
        }
    }


    void Update()
    {
        
    }



    void EnemyDied(Enemy e)
    {
        enemies.Remove(e.gameObject);
        Debug.Log(enemies.Count);
    }
}
