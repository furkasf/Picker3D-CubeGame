using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPoolController : MonoBehaviour
{
    public static BallPoolController instance;

    [SerializeField] GameObject ballPrefab;
    [SerializeField] GameObject ballsConteiner;
    [SerializeField] List<GameObject> ballPools = new List<GameObject>();
    [SerializeField] int ballSize;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        ballPools = CreatBallPool(ballSize);
    }

    public List<GameObject> CreatBallPool(int poolSize)
    {
        for(int i = 0; i < poolSize; i++)
        {
            GameObject ball = Instantiate(ballPrefab);
            ball.transform.parent = ballsConteiner.transform;
            ball.SetActive(false);
            ballPools.Add(ball);
        }

        return ballPools;
    }

    public GameObject GetBallFromPool()
    {
        //cheack any in active ball from pool
        foreach(var ball in ballPools)
        {
            if(ball.activeInHierarchy == false)
            {
                ball.SetActive(true);
                return ball;
            }
        }
        //if doesnt have extra ball in pool creat new ball and pool
        GameObject newBall = Instantiate(ballPrefab);
        newBall.transform.parent = ballsConteiner.transform;
        ballPools.Add(newBall);
        return newBall;
    }

    public void HideAllBalls()
    {
        foreach(var ball in ballPools)
        {
            ball.tag = "Collectable";
            ball.GetComponent<ForceControll>().enabled = false;
            ball.SetActive(false);
        }
    }
}
