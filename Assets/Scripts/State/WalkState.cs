using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    public WalkState(Enemy enemy) : base(enemy)
    {

    }

    public override void EnterState()
    {
        enemy.PlayWalkAnimation();
    }

    public override void Move()
    {
        enemy.MoveToWavePoint(enemy.speed);

        if (enemy.currentpathPointIndex == enemy.pathPoints.Length)
        {
            enemy.ChangeState(enemy.attackState);
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
            enemy.ChangeState(enemy.slowState);
        }
    }
}
