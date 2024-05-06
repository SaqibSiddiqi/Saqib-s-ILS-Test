using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    //Serialized Variables
    [SerializeField]
    private GameObject Manager;
    [SerializeField]
    private GameObject body;
    
    //private Variables
    private GameManager gameManager;
    private Body Body;


    private void Awake()
    {
        gameManager = Manager.GetComponent<GameManager>();
        Body = body.GetComponent<Body>();
    }
    void Update()
    {
        if(gameManager.isPlaying && !Body.gameOver && !Body.bossArea )
        {
            MainMovement();
            Jump();
        }
        GameOver();
        BossArea();
        
    }
    //Reset the gameObject
    void End()
    {
        transform.position = new Vector3(0,0.6f,0);
        Body.bossArea = false;
    }
    //Move during the run section
    void MainMovement()
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
    }
    //Function to Jump
    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && body.GetComponent<Body>().onGround)
        {
            body.GetComponent<Rigidbody>().AddForce(new Vector3(0, 500f, 0));
        }
    }
    //Run on GameOver
    void GameOver()
    {
        if (Body.gameOver)
        {
            End();
            gameManager.EndGame(Body.gameCondition);
        }
    }
    //Run if player has entered BossArea
    bool BossArea()
    {
        if (Body.bossArea)
        {
            BossMovement();
            Jump();
            return true; 
        }
        return false;
    }
    //Run in boss room
    void BossMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float speed = 2f * Time.deltaTime;

        transform.Translate(verticalInput*speed, 0, -horizontalInput*speed);
    }
}
