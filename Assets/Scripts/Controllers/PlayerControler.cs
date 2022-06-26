using System.Collections;
using DG;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    static public PlayerControler instance;

    #region Variables
    [Header("player speed")]
    [SerializeField] float duration;
    public int collectedBallCounter;
    public bool isStop;
    private IPlayerMove move;
    #endregion

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
        if (other.CompareTag("Collectable"))
        {
            collectedBallCounter++;
            other.GetComponent<Rigidbody>().isKinematic = false;
            other.tag = "Collected";
            //instead of adding script companent run time dynamicly this way chiper way to do
            other.GetComponent<ForceControll>().enabled = true; ;
        }
        if (other.CompareTag("FinishLine"))
        {
            isStop = true;
            int curretlevel = LevelController.instance.level;
            int maxlevel = LevelController.instance.maxLevel;
            if(curretlevel < maxlevel && curretlevel != maxlevel -1)
            {
                UIController.instance.nextLevelUI.SetActive(true);
            }
            else
            {
                UIController.instance.winUI.SetActive(true);
            }
        }

    }          
}
