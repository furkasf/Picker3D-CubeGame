using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    static public EventController instance;

    private void Awake()
    {
        if(instance == null) instance = this;
    }

    public event Action ElevetorUpEvent;

    public void ElevatorUp()
    {
        if(ElevetorUpEvent != null)
        {
            ElevetorUpEvent();
        }
    }
}
