using System.Collections;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorControler : MonoBehaviour
{
    [SerializeField] private int ID;

    #region Subscriptions
    private void OnEnable() => SubscribeEvent();
    private void OnDisable() => DeSubscribeEvent();
    private void SubscribeEvent() => EventController.instance.ElevetorUpEvent += OnMoveUpElevator;
    private void DeSubscribeEvent() => EventController.instance.ElevetorUpEvent -= OnMoveUpElevator;
    #endregion

    private void OnMoveUpElevator(int ID)
    {
        if(ID == this.ID)
        {
            transform.DOMoveY(-3.145f, .8f, false);
        }
    }
}
