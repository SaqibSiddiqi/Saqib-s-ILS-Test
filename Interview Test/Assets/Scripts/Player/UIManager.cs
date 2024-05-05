using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //UI groups
    public GameObject Main;
    
    //Public variables
    public GameObject Countdown;
    public GameObject Level;
    
    //Private variables
    private TMP_Text Text_Countdown;
    private TMP_Text Text_Level;

    private void Start()
    {
        Text_Countdown = Countdown.GetComponent<TMP_Text>();
        Text_Level = Level.GetComponent<TMP_Text>();
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
}
