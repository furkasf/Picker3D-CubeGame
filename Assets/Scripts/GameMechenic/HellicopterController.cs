using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HellicopterController : MonoBehaviour
{
    [SerializeField] List<Vector3> targetPossitions;
    [SerializeField] Transform PlayerPosition;
    [SerializeField] Transform Planor;
    [SerializeField] float animationDuration = 1f;
    [SerializeField] GameObject ball;

    void Start()
    {
        //PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        Planor.DORotate(new Vector3(0, 360, 0), animationDuration * 0.5f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
    }


    void Update()
    {
        if (Vector3.Distance(PlayerPosition.position, transform.position) < 2f)
        {
            transform.DOMove(targetPossitions[0], animationDuration).OnComplete(() =>
            {
                transform.DOMove(targetPossitions[1], animationDuration).OnComplete(() =>
                {
                    GameObject bigball = Instantiate(ball);
                    bigball.transform.position = transform.position;
                }).SetEase(Ease.Linear);
            });
            
        }
    }
}
  