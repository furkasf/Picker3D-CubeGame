using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBallController : MonoBehaviour
{

    #region Variables

    #region private Variables
    private Transform _player;
    private Rigidbody _rb;
    private Vector3 _smallBallSpawnPos;
    #endregion

    #endregion

    private void Awake()
    {
        BigBallInitialization();
    }

    private void Update()
    {
        CheakDistanceWithPlayer();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetBalls();
    }

    private void GetBalls()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject ball = BallPoolController.instance.GetBallFromPool();
            if (ball.GetComponent<Rigidbody>().isKinematic == true)
            {
                ball.GetComponent<Rigidbody>().isKinematic = false;
                ball.tag = "Collectable";
            }
            //use to intantiate ball in round shape otherwise balls can spawn out of Plane
            Vector3 circle = Random.insideUnitSphere.normalized * 0.2f;
            ball.transform.position = new Vector3(_smallBallSpawnPos.x + circle.x * 0.5f, _smallBallSpawnPos.y - 1.4f, _smallBallSpawnPos.z + circle.z * 0.5f);
        }
        gameObject.SetActive(false);
    }

    private void BigBallInitialization()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _smallBallSpawnPos = transform.position;
        _rb = GetComponent<Rigidbody>();
    }

    private void CheakDistanceWithPlayer()
    {
        if (Vector3.Distance(_player.position, transform.position) < 15f)
        {
            _rb.isKinematic = false;
        }
        else return;
    }
}
