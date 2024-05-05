using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //UI groups
    public GameObject Main;
    
    //Public variables
    public GameObject Countdown;
    public GameObject Level;
    public GameObject EasyButton;
    public GameObject MediumButton;
    public GameObject HardButton;
    
    //Text variables
    private TMP_Text Text_Countdown;
    private TMP_Text Text_Level;

    //Button variables
    private Button Button_Easy;
    private Button Button_Medium;
    private Button Button_Hard;

    private void Start()
    {
        Text_Countdown = Countdown.GetComponent<TMP_Text>();
        Text_Level = Level.GetComponent<TMP_Text>();
        Button_Easy = EasyButton.GetComponent<Button>();
        Button_Medium = MediumButton.GetComponent<Button>();
        Button_Hard = HardButton.GetComponent<Button>();
    }
    public void SetCoutdown(int count)
    {
        Text_Countdown.text = count.ToString(); 
    }
    public void SetLevelText(int level)
    {
        Text_Level.text = level.ToString();
    }
    public void HideMenu()
    {
        Main.gameObject.SetActive(false);
    }
    public void ShowMenu()
    {
        Main.gameObject.SetActive(true);
    }
    public void ResetMenu()
    {
        Button_Easy.interactable = true;
        Button_Medium.interactable = true;
        Button_Hard.interactable = true;
    }
}
