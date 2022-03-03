using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDecorator : TowerDecorator
{

    public override int GetDamage()
    {
        int newDamage = tower.GetDamage() + 5;
        return newDamage;
    }

}
