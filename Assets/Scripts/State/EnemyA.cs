using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : Enemy
{
    public EnemyA() : base()
    {
        health = 70;
        speed = 1f;
        damage = 10;
    }

    public override void setEnemyTexture()
    {   
        try
        {
            GameObject enemyMeshComponent = transform.Find("Goblin002").gameObject;
            enemyMeshComponent.GetComponent<SkinnedMeshRenderer>().material.mainTexture = Resources.Load<Texture>("Goblin_D");
            enemyMeshComponent.GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color", Color.white);
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }
    }
}
