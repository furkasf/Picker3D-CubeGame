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

    public event Action ObsticalMoveEvent;

    public void ObsticalMove()
    {
        if(ObsticalMoveEvent != null)
        {
            ObsticalMoveEvent();
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

    public IEnumerator SyncTheTrail()
    {
        //just in case some times when prototypin coresponding object dont have in scene and cause annoying errors
        if (PlayerControler.instance != null)
        {
            PlayerControler.instance.isStop = true;
            if (PushCollectableItemEvent != null)
                PushCollectableItemEvent();
            yield return new WaitForSecondsRealtime(2f);
            if (ElevetorUpEvent != null)
                ElevatorUp();
            yield return new WaitForSecondsRealtime(2f);
            if (ObsticalMoveEvent == null)
                ObsticalMove();
            yield return new WaitForSecondsRealtime(2f);
            PlayerControler.instance.isStop = false;
        }
        yield return null;
    }
}
