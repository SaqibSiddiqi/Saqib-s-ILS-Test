using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Serialized Variables
    [SerializeField]
    private GameObject Obstacle_Box;
    [SerializeField]
    private GameObject Boss_Box;
    [SerializeField]
    private GameObject Boss;
    [SerializeField]
    private GameObject Boss_Spawn;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject Player_Body;
    [SerializeField]
    private GameObject Player_Spawn;
    [SerializeField]
    private GameObject MainUI;

    private UIManager UIManager;

    //Public Variables
    public int Level_Select;
    public bool isPlaying = false;

    //Private Variables
    private Vector3 Box_Spawning = new Vector3(7.5f,0,0);
    private GameObject Boss_Room;
    private List<GameObject> Obstacle_Room = new List<GameObject>();


    //On the start of the game
    private void Start()
    {
        UIManager = MainUI.GetComponent<UIManager>();
    }
    private void Update()
    {

    }
    public void StartEasyMode()
    {
        Level_Select = 5;
        StartCoroutine(Countdown(3));
    }
    public void StartMediumMode()
    {
        Level_Select = 15;
        StartCoroutine(Countdown(3));
    }
    public void StartHardMode()
    {
        Level_Select = 30;
        StartCoroutine(Countdown(3));
    }
    private void GetLevel()
    {
        Level_Select = Level_Select * Level_Select;
    }
    //Spawn the obsticales based on the level
    private void SetLevel()
    {
        for(int i = 0; i<Level_Select; i++){
            GameObject created = Instantiate(Obstacle_Box, Box_Spawning, Quaternion.identity);
            Obstacle_Room.Add(created);
            Box_Spawning.x += 10;
        }
        Boss_Room = Instantiate(Boss_Box, Box_Spawning, Quaternion.identity);
    }
    //Start the start game countdown
    public IEnumerator Countdown(int seconds)
    {
        int count = seconds;
        while (count > 0)
        {
            UIManager.SetCoutdown(count);
            yield return new WaitForSeconds(1);
            count--;
        }
        StartGame();
    }
    //Start game sequence
    void StartGame()
    {
        UIManager.HideMenu();
        Player_Body.GetComponent<Body>().gameOver = false;
        SetLevel();
        UIManager.SetLevelText(Level_Select);
        isPlaying = true;
    }
    //On game End, with Game condition define win or loss conditions
    public void EndGame(int gameCondition)
    {
        isPlaying = false;
        UIManager.ShowMenu(gameCondition);
        UIManager.ResetMenu();
        for(int i = 0;i < Obstacle_Room.Count; i++)
        {
            GameObject.Destroy(Obstacle_Room[i]);
        }
        Obstacle_Room.Clear();
        Destroy(Boss_Room);
        Boss_Room = null;
        Box_Spawning = new Vector3(7.5f, 0, 0);
    }
}
