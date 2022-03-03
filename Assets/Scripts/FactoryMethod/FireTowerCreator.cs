using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTowerCreator : TowerCreator
{
    public override GameObject createTower()
    {
        GameObject newTower = Instantiate(Resources.Load("HM_fire_1", typeof(GameObject))) as GameObject;
        newTower.AddComponent<FireTower>();
        return newTower;
    }
}
