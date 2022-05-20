using System.Collections;
using DG;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    static public PlayerControler instance;

    [Header("player speed")]
    public List<GameObject> collectedBalls;
    [SerializeField] float duration;
    public bool isStop;

    IPlayerMove move;

    private void Awake()
    {
        duration = 5f;
        collectedBalls = new List<GameObject>();
        move = GetComponent<PlayerMoveMouse>();
        isStop = false;
        if(instance == null) instance = this;
    }

    private void Update()
    {
       if(!isStop)
           move.Move(duration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Collectable")
        {
            other.tag = "Collected";
            //instead of adding script companent run time dynamicly this way chiper way to do
            other.GetComponent<ForceControll>().enabled = true; ;
            collectedBalls.Add(other.gameObject);
        }
        if (other.tag == "FinishLine") isStop = true; //after add push ford the player to laaderpath also activate the fire particul end of player
    }
}
