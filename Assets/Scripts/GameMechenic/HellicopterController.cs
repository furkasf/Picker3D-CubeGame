using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HellicopterController : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] float _duration;
    [SerializeField] Transform _planor;
    [SerializeField] GameObject _BigballPrefab;

    private void Awake()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Start()
    {
        _planor.DORotate(new Vector3(0, 360, 0), _duration * 0.5f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart);
        _duration = 1.5f;
    }


    void Update()
    {

        if (Vector3.Distance(_target.position, transform.position) < 10f)
        {
            StartCoroutine(SyncAnimations());
        }

    }

    void SpawnBalls()
    {
        GameObject ball = BallPoolController.instance.GetBallFromPool();
        //set as child of parent
        ball.transform.parent = transform.parent;
        ball.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        if (ball.transform.parent.tag != "BallContainer")
        {
            //after balls relocated rechange parent to pool container
            ball.transform.parent = GameObject.FindGameObjectWithTag("BallContainer").transform;
        }
    }

    IEnumerator SyncAnimations()
    {
        Invoke("SpawnBalls", _duration * 0.5f);
        transform.DOLocalMove(new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 10), _duration).SetEase(Ease.Linear);
        yield return new WaitForSecondsRealtime(_duration);
        Invoke("SpawnBalls", _duration * 0.5f);
        transform.DOLocalMove(new Vector3(transform.localPosition.x + 6.5f, transform.localPosition.y, transform.localPosition.z), _duration).SetEase(Ease.Linear);
        yield return new WaitForSecondsRealtime(_duration);
        transform.DOLocalMove(new Vector3(transform.localPosition.x , transform.localPosition.y + 20, transform.localPosition.z), _duration).SetEase(Ease.Linear).OnComplete(() => gameObject.SetActive(false));
        yield return null;
    }
}
  