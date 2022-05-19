using System.Collections;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorControler : MonoBehaviour
{
    private void Start()
    {
        EventController.instance.ElevetorUpEvent += MoveUpElevator;
    }

    void MoveUpElevator()
    {
        transform.DOMoveY(0, 5f, true);
    }

    private void OnDestroy()
    {
        //just in case avoid nullptr error if elevator destroy for some reason 
        EventController.instance.ElevetorUpEvent -= MoveUpElevator;
    }
}
