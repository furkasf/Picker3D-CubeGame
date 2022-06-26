using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ObsticalController : MonoBehaviour
{
    [SerializeField]private Transform _rightObstical;
    [SerializeField]private Transform _leftObstical;
    [SerializeField] private int ID;

    private void Awake()
    {
        _rightObstical = transform.GetChild(0).GetChild(0);
        _leftObstical = transform.GetChild(1).GetChild(0);
    }

    void Start()
    {
        EventController.instance.ObsticalMoveEvent += MoveFromRoad;
    }

    void MoveFromRoad(int ID)
    {
       if(ID == this.ID)
        {
            _rightObstical.DORotate(new Vector3(0, 0, 90), 1);
            _leftObstical.DORotate(new Vector3(0, 0, 90), 1);
            Debug.Log(_rightObstical.name + "          " + _leftObstical.name);
        }
    }

    private void OnDestroy()
    {
        EventController.instance.ObsticalMoveEvent -= MoveFromRoad;
    }
}
