using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public Enemy enemy;
    public State(Enemy enemy)
    {
        this.enemy = enemy;
    }
    public abstract void EnterState();
    public abstract void Move();
    public abstract void TakeDamage(int damage, GameObject bullet);
}
