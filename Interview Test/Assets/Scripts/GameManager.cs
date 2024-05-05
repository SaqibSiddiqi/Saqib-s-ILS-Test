using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
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
    private GameObject Player_Spawn;
    [SerializeField]
    private GameObject MainUI;

    private UIManager UIManager;

    //Public Variables
    public int Level_Select;

    //Private Variables
    private Vector3 Box_Spawning = new Vector3(5,0,0);


    //On the start of the game
    private void Start()
    {
        UIManager = MainUI.GetComponent<UIManager>();
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
    private void SetLevel()
    {
        for(int i = 0; i<Level_Select; i++){
            Instantiate(Obstacle_Box, Box_Spawning, Quaternion.identity);
            Box_Spawning.x += 5;
        }
        Instantiate(Boss_Box, Box_Spawning, Quaternion.identity);
    }
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
    void StartGame()
    {
        UIManager.HideMenu();
        SetLevel();
        UIManager.SetLevelText(Level_Select);
    }
}
