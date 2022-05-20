using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BucketController : MonoBehaviour
{

    public int maxBallCapacity;
    int collectedBallNumber;
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
        if (other.tag == "Collected")
        {
            collectedBallNumber++;
            score.text = maxBallCapacity + " / " + collectedBallNumber;
        }
    }
}
