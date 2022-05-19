using System.Collections;
using DG;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [Header("player speed")]
    [SerializeField] float duration;
    IPlayerMove move;

    private void Awake()
    {
        duration = 5f;
        move = GetComponent<PlayerMoveMouse>();
    }

    private void Update()
    {
        move.Move(duration);
    }

    
}
