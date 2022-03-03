using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    //parametry wieży
    public int damage;
    public float attackSpeed;
    public float bulletSpeed;
    public string bulletName;
    public int value;

    public GameObject target;
    public List<GameObject> targetEnemies = new List<GameObject>();

    public bool isShoot = false;
    public GameObject bulletPrefab;

    public void Update()
    {
        //jezeli przeciwnicy sa w zasiegu, wieza rozpoczyna atak
        if (targetEnemies.Count > 0)
        {
            target = targetEnemies[0];

            if (target == null)
            {
                targetEnemies.Remove(target);
                return;
            }
            else if(target.tag != "Enemy")
            {
                targetEnemies.Remove(target);
                return;
            }

            if (isShoot == false)
            {
                StartCoroutine(Shoot(GetAttackSpeed(), GetBulletSpeed(), GetDamage(), bulletName));
            }
        }
        else
        {
            target = null;
        }
    }

    //jezeli przeciwnik wejdzie w collider wiezy zostaje dodany do listy
    void OnTriggerEnter(Collider other)
    {
        targetEnemies.Add(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        targetEnemies.Remove(other.gameObject);
    }

    public IEnumerator Shoot(float attackS, float bulletS, int dmg, string bulletN)
    {
        isShoot = true;
        yield return new WaitForSeconds(attackS);

        if (target)
        {            
            try
            {
                //stworzenie pocisku
                Vector3 spawn = gameObject.transform.Find("shootElement").position;
                GameObject tempBullet = Instantiate(bulletPrefab, spawn, Quaternion.identity);
                Bullet bullet = tempBullet.GetComponent<Bullet>();
                bullet.target = target.transform;
                bullet.speed = bulletS;
                bullet.damage = dmg;
                bullet.bulletName = bulletN;
            }
            catch (Exception e)
            {
                Debug.LogException(e, this);
            }  
        }

        isShoot = false;
    }

    public abstract void SetBullet();

    public abstract float GetAttackSpeed();

    public abstract float GetBulletSpeed();

    public abstract int GetDamage();

}
