using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Serialized Variables
    [SerializeField]
    private float speed = 0.1f;
    [SerializeField]  
    private float minDist = 1f;
    
    //Private variables
    private Transform target;
    private Transform startPoint;

    //Public Variables
    public GameObject player;
    public GameObject enemy;


    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            target = player.transform;
        }else
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        Activate();
    }

    //Activates the script to start the enemy and move it to the player
    void Activate()
    {
        if(enemy != null)
        {
            if (player.GetComponent<Body>().bossArea)
            {
                // face the target
                enemy.transform.LookAt(target);

                //get the distance between the chaser and the target
                float distance = Vector3.Distance(enemy.transform.position, target.position);

                //so long as the chaser is farther away than the minimum distance, move towards it at rate speed.
                if (distance > minDist)
                    enemy.transform.position += enemy.transform.forward * speed * Time.deltaTime;
            }
        }
        else
        {
            enemy = GameObject.FindGameObjectWithTag("Boss");
        }
        
    }
}
