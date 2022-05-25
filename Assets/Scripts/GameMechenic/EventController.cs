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

    public event Action<int> ElevetorUpEvent;

    public void ElevatorUp(int ID)
    {
        if(ElevetorUpEvent != null)
        {
            ElevetorUpEvent(ID);
        }
    }

    public event Action<int> ObsticalMoveEvent;

    public void ObsticalMove(int ID)
    {
        if(ObsticalMoveEvent != null)
        {
            ObsticalMoveEvent(ID);
        }
    }

    public event Action PushCollectableItemEvent;

    public void PushCollectable()
    {
        if(PushCollectableItemEvent != null)
        {
            PushCollectableItemEvent();
        }
    }

    public IEnumerator SyncTheTrail(int ID)
    {
        //just in case some times when prototypin coresponding object dont have in scene and cause annoying errors
        if (PlayerControler.instance != null)
        {
            PlayerSizeControler.instance.IncreaseSizeOfPlayer();
            yield return new WaitForSecondsRealtime(2f);
            if (ElevetorUpEvent != null)
                ElevatorUp(ID);
            yield return new WaitForSecondsRealtime(0.5f);
            if (ObsticalMoveEvent != null)
                ObsticalMove(ID);
            yield return new WaitForSecondsRealtime(0.2f);
            PlayerControler.instance.isStop = false;
        }
        yield return null;
    }
}
