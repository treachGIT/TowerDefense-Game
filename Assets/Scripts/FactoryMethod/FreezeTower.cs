using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTower : Tower
{
    private void Awake()
    {
        SetBullet();
    }

    public override void SetBullet()
    {
        targetEnemies = new List<GameObject>();

        try
        {
            bulletPrefab = Resources.Load("freeze_bullet", typeof(GameObject)) as GameObject;
            bulletPrefab.GetComponent<Renderer>().sharedMaterial.SetColor("_Color", Color.blue);
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }
    }

    public FreezeTower()
    {
        damage = 5;
        attackSpeed = 1f;
        bulletSpeed = 8f;
        bulletName = "freeze";
        value = 40;
    }
    public override float GetAttackSpeed()
    {
        return attackSpeed;
    }

    public override float GetBulletSpeed()
    {
        return bulletSpeed;
    }

    public override int GetDamage()
    {
        return damage;
    }

}
