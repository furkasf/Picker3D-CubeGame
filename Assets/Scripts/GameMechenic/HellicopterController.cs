using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HellicopterController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float duration;
    [SerializeField] Transform planor;
    
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        planor = transform.GetChild(1);
    }

    void Start()
    {
        planor.DOLocalRotate(new Vector3(0, 360, 0), 1f, RotateMode.FastBeyond360).SetLoops(-1);
        duration = 1.5f;
    }


    void Update()
    {

        if (Vector3.Distance(target.position, transform.position) < 10f)
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
        Invoke("SpawnBalls", duration * 0.5f);
        transform.DOLocalMove(new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 10), duration).SetEase(Ease.Linear);
        yield return new WaitForSecondsRealtime(duration);
        Invoke("SpawnBalls", duration * 0.5f);
        transform.DOLocalMove(new Vector3(transform.localPosition.x + 6.5f, transform.localPosition.y, transform.localPosition.z), duration).SetEase(Ease.Linear);
        yield return new WaitForSecondsRealtime(duration);
        transform.DOLocalMove(new Vector3(transform.localPosition.x , transform.localPosition.y + 20, transform.localPosition.z), duration).SetEase(Ease.Linear).OnComplete(() => gameObject.SetActive(false));
        yield return null;
    }
}
  