using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("triggered");
            PlayerControler.instance.isStop = true;
            EventController.instance.PushCollectable();
        }
    }

}
