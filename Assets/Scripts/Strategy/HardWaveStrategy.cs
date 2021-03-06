using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardWaveStrategy : MonoBehaviour, WaveStrategy
{
    public List<GameObject> GenerateWave(int waveCount, Vector3 spawnPlace, GameObject enemyPrefab)
    {
        List<GameObject> enemies = new List<GameObject>();
        int tempCount = waveCount * waveCount;

        float timeInterval = 1f;

        for(int i=0; i < tempCount + 3; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, spawnPlace, Quaternion.identity);
            enemy.AddComponent<EnemyA>();
            enemies.Add(enemy);
            enemy.GetComponent<EnemyA>().Spawn(timeInterval);
            timeInterval += 3f;
        }

        timeInterval = 1f;
        for (int i = 0; i < tempCount + 2; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, spawnPlace, Quaternion.identity);
            enemy.AddComponent<EnemyB>();
            enemies.Add(enemy);
            enemy.GetComponent<EnemyB>().Spawn(timeInterval);
            timeInterval += 2f;
        }

        return enemies;
    }


}
