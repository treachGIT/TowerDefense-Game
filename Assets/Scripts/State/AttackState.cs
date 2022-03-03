using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public AttackState(Enemy enemy) : base(enemy)
    {

    }

    public override void EnterState()
    {
        enemy.PlayAttackAnimation();
        enemy.AttackHandler();
    }

    public override void Move()
    {
    }

    public override void TakeDamage(int damage, GameObject bullet)
    {
        enemy.health -= damage;

        if (enemy.health <= 0)
        {
            enemy.PlayDeathAnimation();
        }
    }

}
