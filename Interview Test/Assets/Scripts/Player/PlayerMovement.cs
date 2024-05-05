using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Serialized Variables
    [SerializeField]
    private GameObject Manager;
    
    //private Variables
    private GameManager gameManager;


    private void Awake()
    {
        gameManager = Manager.GetComponent<GameManager>();
    }
}
