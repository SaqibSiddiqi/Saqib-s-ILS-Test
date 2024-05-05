using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Serialized Variables
    [SerializeField]
    private GameObject Manager;
    [SerializeField]
    private GameObject body;
    
    //private Variables
    private GameManager gameManager;


    private void Awake()
    {
        gameManager = Manager.GetComponent<GameManager>();
    }
    void Update()
    {
        if(gameManager.isPlaying)
        {            
            float horizontalinput = Input.GetAxis("Horizontal");
            switch (horizontalinput)
            {
                case -1:
                    transform.position = new Vector3(transform.position.x, transform.position.y, 1.5f);
                    transform.Translate(0.05f, 0, 0);
                    break;
                case 1:
                    transform.position = new Vector3(transform.position.x, transform.position.y, -1.5f);
                    transform.Translate(0.05f, 0, 0);
                    break;
                default:
                    transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                    transform.Translate(0.05f, 0, 0);
                    break;
            }
            if(Input.GetKey(KeyCode.Space) && body.GetComponent<Body>().onGround)
            {
                body.GetComponent<Rigidbody>().AddForce(new Vector3(0, 500f, 0));
            }
            if(body.GetComponent<Body>().gameOver) 
            {
                End();
                gameManager.EndGame();
            }
        }
    }
    void End()
    {
        transform.position = new Vector3(0,0.6f,0);
    }
}
