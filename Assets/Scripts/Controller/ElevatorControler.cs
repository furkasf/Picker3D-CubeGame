using System.Collections;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorControler : MonoBehaviour
{
    [SerializeField] private int ID;

    private void Start()
    {
        EventController.instance.ElevetorUpEvent += MoveUpElevator;
    }

    void MoveUpElevator(int ID)
    {
        if(ID == this.ID)
        {
            transform.DOMoveY(0, 5f, true);
        }
    }

    private void OnDestroy()
    {
        //just in case avoid nullptr error if elevator destroy for some reason 
        EventController.instance.ElevetorUpEvent -= MoveUpElevator;
    }
}
