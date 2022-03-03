using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface WaveStrategy
{
    //strategia zawiera metodę GenerateWave ktora tworzy listę przeciwnikow na nastepna fale
    List<GameObject> GenerateWave(int waveCount, Vector3 spawnPlace , GameObject enemyPrefab);


}
