using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBallController : MonoBehaviour
{
    Transform player;
    Rigidbody rb;
    Vector3 smallBallSpawnPos;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        smallBallSpawnPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Vector3.Distance(player.position, transform.position) < 20f)
        {
            rb.isKinematic = false;
        }
    }

    void GetBalls()
    {
        for(int i = 0; i < 5; i++)
        {
            GameObject ball = BallPoolController.instance.GetBallFromPool();
            //use to intantiate ball in round shape otherwise balls can spawn out of scene
            Vector3 circle = Random.insideUnitSphere.normalized * 0.5f;
            ball.transform.position = new Vector3(smallBallSpawnPos.x + circle.x, smallBallSpawnPos.y , smallBallSpawnPos.z + circle.z);
        }
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetBalls();
    }
}
