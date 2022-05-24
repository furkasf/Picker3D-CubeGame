using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HellicopterController : MonoBehaviour
{
    [SerializeField] Transform PlayerPosition;
    [SerializeField] Transform Planor;
    [SerializeField] float animationDuration = 1f;
    [SerializeField] GameObject ball;
    Sequence seq;
    bool animationTrigger = false;

    void Start()
    {
        PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        Planor.DORotate(new Vector3(0, 360, 0), animationDuration * 0.5f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
    }


    void Update()
    {

        if (Vector3.Distance(PlayerPosition.position, transform.position) < 5f)
        {
            animationTrigger = true;

        }
        if(animationTrigger)
        {
            Invoke("DropBalls", 1.5f);
            BallPoolController.instance.GetBallFromPool();
            seq = DOTween.Sequence();
            seq.Append(transform.DOMove(new Vector3(0 ,0, 6), animationDuration))
                .Append(transform.DOMove(new Vector3(4, 0, 0), animationDuration))
                .Append(transform.DOMove(new Vector3(0, 0, 13), animationDuration))
                .Append(transform.DOMove(new Vector3(0, 10, 0), animationDuration)).SetEase(Ease.InSine).OnComplete(() => gameObject.SetActive(false));
        }
        
    }

   void DropBalls()
    {
        GameObject ball = BallPoolController.instance.GetBallFromPool();
        ball.transform.position = transform.position;
    }
}
  