using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ObsticalController : MonoBehaviour
{
    #region Variables
    #region Serialize Variables
    [SerializeField]private Transform RightObstical;
    [SerializeField]private Transform LeftObstical;
    [SerializeField] private int ID;
    #endregion
    #endregion

    private void Awake()
    {
        InitializeObstical();
    }

    private void Start()
    {
        SubscribeEvent();
    }

    #region Subscriptions
    //private void OnEnable() => SubscribeEvent();
    private void OnDisable() => DeSubscribeEvent();
    private void SubscribeEvent() => EventController.instance.ObsticalMoveEvent += MoveFromRoad;
    private void DeSubscribeEvent() => EventController.instance.ObsticalMoveEvent -= MoveFromRoad;
    #endregion

    private void MoveFromRoad(int ID)
    {
       if(ID == this.ID)
        {
            RightObstical.DORotate(new Vector3(0, 0, 90), 1);
            LeftObstical.DORotate(new Vector3(0, 0, 90), 1);
            Debug.Log(RightObstical.name + "          " + LeftObstical.name);
        }
    }

    private void InitializeObstical()
    {
        RightObstical = transform.GetChild(0).GetChild(0);
        LeftObstical = transform.GetChild(1).GetChild(0);
    }
}
