using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowState : State
{
    public SlowState(Enemy enemy) : base(enemy)
    {

    }

    public override void EnterState()
    {
        enemy.PlaySlowAnimation();

        try
        {
            GameObject enemyMeshComponent = enemy.transform.Find("Goblin002").gameObject;
            enemyMeshComponent.GetComponent<SkinnedMeshRenderer>().material.mainTexture = Resources.Load<Texture>("Goblin_D");
            enemyMeshComponent.GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color", Color.blue);
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }

        enemy.SlowEnemy();
    }

    public override void Move()
    {
        enemy.MoveToWavePoint(enemy.speed/2);

        if (enemy.currentpathPointIndex == enemy.pathPoints.Length)
        {
            enemy.setEnemyTexture();
            enemy.ChangeState(enemy.attackState);
        }
        else if (enemy.slowCount == 0)
        {
            enemy.setEnemyTexture();
            enemy.ChangeState(enemy.walkState);
        }
    }

    public override void TakeDamage(int damage, GameObject bullet)
    {
        enemy.health -= damage;

        if (enemy.health <= 0)
        {
            enemy.PlayDeathAnimation();
        }
        else if (bullet.GetComponent<Bullet>().bulletName == "freeze")
        {
            enemy.SlowEnemy();
        }
    }
}
