using System.Collections;
using DG;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    static public PlayerControler instance;

    [Header("player speed")]
    [SerializeField] float duration;
    public int collectedBallCounter;
    public bool isStop;



    IPlayerMove move;

    private void Awake()
    {
        duration = 5f;
        isStop = true;    
        move = GetComponent<PlayerMoveMouse>();
        collectedBallCounter = 0;
        if(instance == null) instance = this;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && UIController.instance.startUI.active)
        {
            isStop = false;
            UIController.instance.startUI.SetActive(false);
        }
        if (!isStop) move.Move(duration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectable")
        {
            collectedBallCounter++;
            other.tag = "Collected";
            //instead of adding script companent run time dynamicly this way chiper way to do
            other.GetComponent<ForceControll>().enabled = true; ;
        }
        if (other.tag == "FinishLine")
        {
            isStop = true;
            UIController.instance.nextLevelUI.SetActive(true);
            //after add push ford the player to laaderpath also activate the fire particul end of player
        }

    }          
}
