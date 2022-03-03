using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    public float speed;
    public int damage;
    public string bulletName;
    Vector3 targetSavePos;

    void Update()
    {
        if (target)
        {
            //pocisk porusza się w stronę celu
            transform.LookAt(target);
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);

            targetSavePos = target.position;
        }
        else
        {
            //jezeli cel pocisku został juz zniszczony, pocisk rowniez ulega zniszczeniu po sekundzie
            Destroy(this.gameObject, 1f);

            transform.LookAt(targetSavePos);
            transform.position = Vector3.MoveTowards(transform.position, targetSavePos, Time.deltaTime * speed);
        }
      
    }

    void OnTriggerEnter(Collider other)
    {  
        if(target != null)
        {
            if (other.gameObject == target.gameObject)
            {
                //jezeli pocisk trafil we wlasciwy cel, zadaje obrazenia przeciwnikowi

                try
                {
                    target.gameObject.GetComponent<Enemy>().TakeDamage(damage, this.gameObject);                 
                }
                catch (Exception e)
                {
                    Debug.LogException(e, this);
                }

                Destroy(this.gameObject);
            }
        }

        if(other.gameObject.tag != "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
