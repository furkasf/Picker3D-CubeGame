using System.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BucketController : MonoBehaviour
{
    #region Variables

    #region SerializeVariable
    [SerializeField] int collectedBallNumber;
    [SerializeField] List<GameObject> balls;
    [SerializeField] private int ID;
    #endregion

    #region PublicVariable
    public int maxBallCapacity;
    #endregion

    #region PrivateVariable
    private TextMeshPro _score;
    #endregion

    #endregion

    private void Awake()
    {
        BucketInitialization();
    }

    private void OnTriggerEnter(Collider other)
    {
 
        if(other.CompareTag("Collected") || other.CompareTag("Collectable") )
        {
            UpdateGameScore(other);
    
        }

        UpdateBasketScore();

        if (collectedBallNumber >= maxBallCapacity)
        {
            BasketOnFull();
        }
        else if(collectedBallNumber < maxBallCapacity && PlayerControler.instance.collectedBallCounter < maxBallCapacity)
        {
            BasketNotFull();
        }
    }

    private void BucketInitialization()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name == "Score")
            {
                _score = transform.GetChild(i).GetComponent<TextMeshPro>();
                break;
            }
        }
        _score.text = maxBallCapacity + " / " + collectedBallNumber;
        collectedBallNumber = 0;
    }

    #region ScoresUpdates
    private void UpdateGameScore(Collider other)
    {
        collectedBallNumber++;
        balls.Add(other.gameObject);
        //also increase Score
        UIController.instance.score++;
        int gameScore = UIController.instance.score;
        UIController.instance.ScoreText.text = "Score" + " : " + gameScore;
    }
    private void UpdateBasketScore() => _score.text = maxBallCapacity + " / " + collectedBallNumber;
    #endregion


    #region BasketBehaviors

    private void BasketOnFull()
    {
        foreach (var ball in balls)
        {
            ball.tag = "Collectable";
            ball.GetComponent<ForceControll>().enabled = false;
            ball.SetActive(false);
        }
        //add particul if you find a time
        StartCoroutine(EventController.instance.SyncTheTrail(ID));
        PlayerControler.instance.collectedBallCounter = 0;
    }

    private void BasketNotFull()
    {
        foreach (var ball in balls) ball.SetActive(false);

        UIController.instance.loseUI.SetActive(true);
        PlayerControler.instance.isStop = true;
        PlayerControler.instance.collectedBallCounter = 0;
    }
    #endregion

}
