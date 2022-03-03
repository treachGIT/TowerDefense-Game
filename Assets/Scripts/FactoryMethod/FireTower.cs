using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : Tower
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
            bulletPrefab = Resources.Load("fire_bullet", typeof(GameObject)) as GameObject;
            bulletPrefab.GetComponent<Renderer>().sharedMaterial.SetColor("_Color", Color.red);
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }
    }

    public FireTower()
    {
        damage = 10;
        attackSpeed = 1f;
        bulletSpeed = 10f;
        bulletName = "fire";
        value = 50;
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
