using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController 
{
    public int waveCount = 0;
    public List<GameObject> enemies = new List<GameObject>();
    private WaveStrategy currentStrategy;
    private Vector3 spawnPlace;
    private GameObject enemyPrefab;

    public WaveController(GameObject spawnPortal, GameObject enemyPrefab)
    {
        spawnPlace = spawnPortal.transform.position;
        this.enemyPrefab = enemyPrefab;
    }

    public void ChangeStrategy(WaveStrategy strategy)
    {
        currentStrategy = strategy;
    }

    //tworzenie fali przy uzyciu wybranej strategii
    public void GenerateWave()
    {
        waveCount++;
        
        enemies = currentStrategy.GenerateWave(waveCount, spawnPlace, enemyPrefab);

        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<Enemy>().setEnemyTexture();
            enemy.tag = "Enemy";
        }  
    }

    public void SetWavePath(Transform [] pathPoints)
    {
        try
        {
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<Enemy>().pathPoints = pathPoints;
            }
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
   
    }

    //sprawdzenie czy fala została zakończona
    public bool IfWaveEnded()
    {
        int activeCount = 0;
        foreach (GameObject enemy in enemies)
        {
            //jezeli przeciwnik zostal zniszczony
            if (enemy != null)
                activeCount++;      
        }

        if (activeCount == 0)
            return true;
        else
            return false;
    }

}
