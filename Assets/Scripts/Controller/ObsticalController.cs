using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ObsticalController : MonoBehaviour
{
   
    void Start()
    {
        EventController.instance.ObsticalMoveEvent += MoveFromRoad;
    }

    void MoveFromRoad()
    {
        transform.DOMoveX(5, 3, true);
    }

    private void OnDestroy()
    {
        EventController.instance.ObsticalMoveEvent -= MoveFromRoad;
    }
}
