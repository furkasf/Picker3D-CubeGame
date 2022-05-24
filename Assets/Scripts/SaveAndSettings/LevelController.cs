using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    public static LevelController instance;
    public GameSettings gameSettings;
    public Transform Player;
    public int level = 0;
    public int maxLevel = 3;

    private void Awake()
    {
        if(instance == null) instance = this;
        Instantiate(gameSettings.LevelPrefabs[0].gameObject, GameObject.Find("TheLevelContailner").transform);
       
    }

    public void NextLevel()
    {
        level++;
        if (level < maxLevel)
        {
            BallPoolController.instance.HideAllBalls();
            PlayerControler.instance.collectedBallCounter = 0;
            Destroy(GameObject.Find("TheLevelContailner").transform.GetChild(0).gameObject);
            Instantiate(gameSettings.LevelPrefabs[level].gameObject, GameObject.Find("TheLevelContailner").transform);
            Player.position = gameSettings.playerDefaultPos;
            //save the progress
            int currenScore = UIController.instance.score;
            SaveController.instance.SaveGame(currenScore);
            UIController.instance.nextLevelUI.SetActive(false);
            UIController.instance.startUI.SetActive(true);
            return;

        }
        else
        {
            //reset save record
            BallPoolController.instance.HideAllBalls();
            SaveController.instance.SaveGame(0);
            UIController.instance.nextLevelUI.SetActive(false);
            UIController.instance.winUI.SetActive(true);
        }
    }
    public void RestartLevel()
    {
        if (File.Exists(Application.persistentDataPath + "/Picker3D.save"))
        {
            BallPoolController.instance.HideAllBalls();
            Save saveFile = SaveController.instance.LoadGameSave();
            PlayerControler.instance.collectedBallCounter = 0;
            Destroy(GameObject.Find("TheLevelContailner").transform.GetChild(0).gameObject);
            Instantiate(gameSettings.LevelPrefabs[level].gameObject, GameObject.Find("TheLevelContailner").transform);
            UIController.instance.score = saveFile.score;
            UIController.instance.ScoreText.text = "Score : " + saveFile.score;
            Player.position = gameSettings.playerDefaultPos;
            UIController.instance.loseUI.SetActive(false);
            UIController.instance.startUI.SetActive(true);
            return;
        }
        else
        {
            //because if save file doesnt created that mean player still first level
            BallPoolController.instance.HideAllBalls();
            UIController.instance.score = 0;
            UIController.instance.ScoreText.text = "Score : " + 0;
            PlayerControler.instance.collectedBallCounter = 0;
            Destroy(GameObject.Find("TheLevelContailner").transform.GetChild(0).gameObject);
            Instantiate(gameSettings.LevelPrefabs[0].gameObject, GameObject.Find("TheLevelContailner").transform);
            PlayerControler.instance.isStop = true;
            Player.position = gameSettings.playerDefaultPos;
            UIController.instance.loseUI.SetActive(false);
            UIController.instance.startUI.SetActive(true);
        }
    }

    public void RestartGame()
    {
        level = 0;
        BallPoolController.instance.HideAllBalls();
        PlayerControler.instance.collectedBallCounter = 0;
        Destroy(GameObject.Find("TheLevelContailner").transform.GetChild(0).gameObject);
        SaveController.instance.SaveGame(0);
        Instantiate(gameSettings.LevelPrefabs[0].gameObject, GameObject.Find("TheLevelContailner").transform);
        Player.position = gameSettings.playerDefaultPos;
        UIController.instance.winUI.SetActive(false);
        UIController.instance.startUI.SetActive(true);
        UIController.instance.score = 0;
        UIController.instance.ScoreText.text = "Score : " + 0;
    }
}
