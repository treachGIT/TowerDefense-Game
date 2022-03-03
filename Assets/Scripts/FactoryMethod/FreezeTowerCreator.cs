using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTowerCreator : TowerCreator
{
    public override GameObject createTower()
    {
        GameObject newTower = Instantiate(Resources.Load("EL_splash_1", typeof(GameObject))) as GameObject;
        newTower.AddComponent<FreezeTower>();
        return newTower;
    }
}
