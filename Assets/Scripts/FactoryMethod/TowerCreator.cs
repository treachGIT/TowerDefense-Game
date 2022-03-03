using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerCreator : MonoBehaviour
{
    public abstract GameObject createTower();

    public GameObject placeTower(Vector3 position)
    {
        GameObject tower = createTower();
        tower.transform.position = position;

        return tower;
    }
}
