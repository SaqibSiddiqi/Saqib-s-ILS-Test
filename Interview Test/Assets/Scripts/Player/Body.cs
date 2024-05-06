using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    //public variables
    public bool onGround;
    public bool gameOver = false;
    public bool bossArea = false;
    public int gameCondition = 0;

    private void OnCollisionStay(Collision collision)
    {
        //Check to see if player is touching the ground to enable jump
        if(collision.gameObject.tag == "Structure")
        {
            onGround = true;
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        //Check to see if player has jumped
        onGround = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            //Check to see if Barrier was hit
            case "Obstacle":
                gameOver = true;
                gameCondition = 1;
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            //Check to see if player enters the boss area
            case "Boss_Area":
                bossArea = true;
                break;
            //Check to see if player has hit the boss
            case "Finish":
                gameOver = true;
                gameCondition = 2;
                break;
            //Check to see if player has been hit by a weapon
            case "Weapon":
                gameOver = true;
                gameCondition = 1;
                break;
        }
    }
}
