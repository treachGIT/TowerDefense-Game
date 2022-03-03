using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedDecorator : TowerDecorator
{
    public override float GetAttackSpeed()
    {
        float attackBulletSpeed = tower.GetAttackSpeed() - 0.1f;
        return attackBulletSpeed;
    }
}
