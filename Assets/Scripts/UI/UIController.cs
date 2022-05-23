using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    [Header("UI items")]
    public GameObject winUI;
    public GameObject loseUI;
    public GameObject nextLevelUI;
    public GameObject startUI;
    public TMP_Text ScoreText;
    public int score;

    private void Awake()
    {
        if(instance == null) instance = this;        
    }

    private void Start()
    {
        ActivateStartUI();
    }

    //you can use bool to made more generic these funtions
    public void ActivateWinUI()
    {
        winUI.SetActive(true);      
    }
    public void ActivateLoseUI()
    {
        loseUI.SetActive(true);
    }
    public void ActivateNextLevelUI()
    {
        nextLevelUI.SetActive(true);
    }

    public void ActivateStartUI()
    {
        startUI.SetActive(true);
        PlayerControler.instance.isStop = true;
    }
}
