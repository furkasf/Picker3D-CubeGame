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
        if(Vector3.Distance(player.position, transform.position) < 15f)
        {
            rb.isKinematic = false;
        }
    }

    void GetBalls()
    {
        for(int i = 0; i < 5; i++)
        {
            GameObject ball = BallPoolController.instance.GetBallFromPool();
            if(ball.GetComponent<Rigidbody>().isKinematic == true)
            {
                ball.GetComponent<Rigidbody>().isKinematic = false;
                ball.tag = "Collectable";
            }
            //use to intantiate ball in round shape otherwise balls can spawn out of Plane
            Vector3 circle = Random.insideUnitSphere.normalized * 0.2f;
            ball.transform.position = new Vector3(smallBallSpawnPos.x + circle.x * 0.5f, smallBallSpawnPos.y - 1.4f , smallBallSpawnPos.z + circle.z * 0.5f);
        }
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetBalls();
    }
}
