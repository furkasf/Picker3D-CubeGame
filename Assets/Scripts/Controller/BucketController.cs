using System.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BucketController : MonoBehaviour
{
    [SerializeField] private int ID;
    public int maxBallCapacity;
    [SerializeField]int collectedBallNumber;
    TextMeshPro score;

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).name == "Score")
            {
                score = transform.GetChild(i).GetComponent<TextMeshPro>();
                break;
            }
        }
        score.text = maxBallCapacity + " / " + collectedBallNumber;
        collectedBallNumber = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
 
        collectedBallNumber++;
        //for not trriger with same object
        //other.gameObject.GetComponent<SphereCollider>().enabled = false;
        score.text = maxBallCapacity + " / " + collectedBallNumber;

        //that long compational expensive aproac refatored basicly use ball counter in plater class
        #region
        ////if collected balls >= max ballcapatiy => destroy ball and start coroutine
        ////after clean up all balls from list
        //if (collectedBallNumber >= maxBallCapacity)
        //{
           
        //    foreach(GameObject ball in PlayerControler.instance.collectedBalls.ToList())
        //    {
        //        if(ball != null)
        //        {
        //            Destroy(ball, 0.2f);
        //            PlayerControler.instance.collectedBalls.Remove(ball);
        //        }
        //    }
        //    StartCoroutine(EventController.instance.SyncTheTrail(ID));

        //}

        //else if(PlayerControler.instance.collectedBalls.Count < maxBallCapacity || maxBallCapacity < collectedBallNumber)
        //{
        //    //ToList() just temporary solution if you have time refator code best way to deal with collection modification in foreach
        //    foreach (GameObject ball in PlayerControler.instance.collectedBalls.ToList())
        //    {
        //        if (ball != null)
        //        {
        //            Destroy(ball, 0.2f);
        //            PlayerControler.instance.collectedBalls.Remove(ball);
        //        }
        //    }
        //    Debug.Log("game over");
        //    //start coroutine weait 3 sec and activate lose ui
        //    //start coroutine weait 3 sec and activate lose ui
            
        //}
        #endregion

        if(collectedBallNumber >= maxBallCapacity)
        {
            Destroy(other.gameObject, 0.2f);
            //add particul if you find a time
            StartCoroutine(EventController.instance.SyncTheTrail(ID));
            PlayerControler.instance.collectedBallCounter = 0;
            collectedBallNumber = 0;
        }
        else if(PlayerControler.instance.collectedBallCounter < maxBallCapacity && collectedBallNumber < maxBallCapacity)
        {
            Destroy(other.gameObject, 0.2f);
            UIController.instance.loseUI.SetActive(true);
            PlayerControler.instance.isStop = true;
            collectedBallNumber = 0;
        }
    }

}
