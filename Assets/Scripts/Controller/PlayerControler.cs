using System.Collections;
using DG;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    static public PlayerControler instance;

    [Header("player speed")]
    [SerializeField] float duration;
    public bool isStop;

    IPlayerMove move;

    private void Awake()
    {
        duration = 5f;
        move = GetComponent<PlayerMoveMouse>();
        isStop = false;
        if(instance == null) instance = this;
    }

    private void Update()
    {
       // if(!_isStop)
         //   move.Move(duration);
    }

    
}
