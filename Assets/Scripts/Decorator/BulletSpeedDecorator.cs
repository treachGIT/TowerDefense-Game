using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeedDecorator : TowerDecorator
{
    public override float GetBulletSpeed()
    {
        float newBulletSpeed = tower.GetBulletSpeed() + 1f;
        return newBulletSpeed;
    }
}
