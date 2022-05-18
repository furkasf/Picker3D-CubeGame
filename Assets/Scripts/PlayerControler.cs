using System.Collections;
using DG.Tweening;
using DG;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [Header("player speed")]
    [SerializeField] float speed;
    private Vector3 _touchEnd;
    private Vector3 _touchStart;

    private void Awake()
    {
        speed = 10f;
    }

    private void Update()
    {
        ReadPlayerInput();
    }

    void ReadPlayerInput()
    {
        transform.position += Vector3.forward * Time.deltaTime;
       
        #region Mouse Input
        if(Input.GetMouseButtonDown(0))
        {
            _touchStart = Input.mousePosition;
        }

        else if(Input.GetMouseButton(0))
        {
            _touchEnd = Input.mousePosition - _touchStart;
            float move = Mathf.Clamp(_touchEnd.x, -5, 5);
            transform.DOMoveX(move, 2, false);
        }
        _touchEnd = _touchStart = Vector3.zero;
        #endregion
    }
}