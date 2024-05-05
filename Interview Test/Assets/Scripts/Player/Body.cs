using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    //public variables
    public bool onGround;
    public bool gameOver = false;

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Structure")
        {
            onGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        onGround = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            gameOver = true;
        }
    }
}
