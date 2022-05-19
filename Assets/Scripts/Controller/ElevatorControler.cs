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

    public void MoveUpElevator()
    {
        transform.DOMoveY(0, 1.5f, true);
    }
}
