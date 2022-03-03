using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerDecorator : Tower
{
    public Tower tower;

    public void SetTower(Tower tower)
    {    
        this.tower = tower;
        SetBullet();       
    }

    public override void SetBullet()
    {
        bulletPrefab = this.tower.bulletPrefab;
        bulletName = this.tower.bulletName;
    }

    public override float GetAttackSpeed()
    {
        return tower.GetAttackSpeed();
    }

    public override float GetBulletSpeed()
    {
        return tower.GetBulletSpeed();
    }

    public override int GetDamage()
    {
        return tower.GetDamage();
    }
}
