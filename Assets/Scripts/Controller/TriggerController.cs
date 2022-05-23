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
            if(PlayerControler.instance.collectedBallCounter == 0)
            {
                UIController.instance.loseUI.SetActive(true);
                PlayerControler.instance.isStop = true;
                PlayerControler.instance.collectedBallCounter = 0;
            }
            EventController.instance.PushCollectable();
        }
    }

}
