using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyB : Enemy
{
    public EnemyB() : base()
    {
        health = 50;
        speed = 2f;
        damage = 30;
    }

    public override void setEnemyTexture()
    {
        try
        {
            GameObject enemyMeshComponent = transform.Find("Goblin002").gameObject;
            enemyMeshComponent.GetComponent<SkinnedMeshRenderer>().material.mainTexture = Resources.Load<Texture>("Goblin_A");
            enemyMeshComponent.GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color", Color.white);
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }
    }

}
