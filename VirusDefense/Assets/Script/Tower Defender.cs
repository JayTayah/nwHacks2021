using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform target;
    public float range = 15f;

    public string enemyTag = "Enemy";
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget",0f,0.5f);
        //Invoke UpdateTarget() after 0 second, repat rate 0.5 second
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObjecct.FindGameObjectWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position,enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
            
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
           else
        {
            target = null;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            return;
        }

     
    }


}
