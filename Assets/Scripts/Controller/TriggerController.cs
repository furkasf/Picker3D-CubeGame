using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            EventController.instance.ElevatorUp();
            EventController.instance.ObsticalMove();
            EventController.instance.PushCollectable();
        }
    }

}
