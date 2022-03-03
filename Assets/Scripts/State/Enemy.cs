using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    //parametry przeciwnika
    public int health;
    public int damage;
    public float speed;

    //droga przeciwnika sklada się z okreslonej liczby punktow
    public Transform[] pathPoints;
    //informacja w ktorym z punktow znajduje sie obecnie przeciwnik
    public int currentpathPointIndex= 0;

    public State currentState;

    public WalkState walkState;
    public SlowState slowState;
    public AttackState attackState;

    public Animator animator;

    public bool isMoving = false;
    public int slowCount = 0;

    public abstract void setEnemyTexture();

    public Enemy()
    {     
        walkState = new WalkState(this);
        slowState = new SlowState(this);
        attackState = new AttackState(this);
    }

    public void Awake()
    {
        try
        {
            animator = GetComponent<Animator>();
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }
       
        ChangeState(walkState);
    }

    public void Update()
    {
        if (isMoving)
        {
            currentState.Move();
        }
    }

    public void TakeDamage(int damage, GameObject bullet)
    {
        currentState.TakeDamage(damage, bullet);
    }

    public void ChangeState(State newState)
    {
        currentState = newState;
        currentState.EnterState();
    }

    public void PlayWalkAnimation()
    {
        animator.speed = 1f;
        animator.SetBool("Attack", false);
        animator.SetBool("RUN", true);
    }

    public void PlaySlowAnimation()
    {
        animator.speed = 0.5f;
    }

    public void PlayAttackAnimation()
    {
        animator.speed = 1f;
        animator.SetBool("RUN", false);
        animator.SetBool("Attack", true);
    }

    public void PlayDeathAnimation()
    {
        this.gameObject.tag = "Untagged";
        animator.speed = 1f;
        speed = 0f;
        animator.SetBool("Death", true);
        Destroy(this.gameObject, 2f);
    }

    public void MoveToWavePoint(float currentSpeed)
    {
        if (currentpathPointIndex < pathPoints.Length)
        {
            //przeciwnik porusza sie w stronę wyznaczonego punktu
            transform.position = Vector3.MoveTowards(transform.position, pathPoints[currentpathPointIndex].position, Time.deltaTime * currentSpeed);
            transform.LookAt(pathPoints[currentpathPointIndex].position);

            //po osiagnięciu wymaganej odległości przeciwnik zmienia cel
            if (Vector3.Distance(transform.position, pathPoints[currentpathPointIndex].position) < 0.3f)
            {
                currentpathPointIndex++;
            }
        }
    }

    //Spawnowanie przeciwników z określonym opóźnieniem
    public void Spawn(float spawnTime)
    {
        StartCoroutine(SpawnEnemy(spawnTime));
    }
    IEnumerator SpawnEnemy(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        isMoving = true;
    }

    //Nałożenie spowolnienia
    public void SlowEnemy()
    {
        slowCount++;
        StartCoroutine(SlowEnemyCounter());
    }
    IEnumerator SlowEnemyCounter()
    {
        yield return new WaitForSeconds(1.5f);

        slowCount--;
    }

    public void AttackHandler()
    {
        StartCoroutine(AttackTimer());
    }

    public IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(1.4f);

        try
        {
            GameObject playerBase = GameObject.FindGameObjectWithTag("PlayerBase");
            playerBase.GetComponent<PlayerBase>().TakeDamage(damage);
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }

        Destroy(this.gameObject);
    }


  
}
