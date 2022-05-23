using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameSettings gameSettings;
    public Transform Player;
    int level = 0;
    int maxLevel = 3;

    private void Awake()
    {
       
        Instantiate(gameSettings.LevelPrefabs[0].gameObject, GameObject.Find("TheLevelContailner").transform);
       
    }

    public void NextLevel()
    {
        level++;
        if (level < maxLevel)
        {
            PlayerControler.instance.collectedBallCounter = 0;
            Destroy(GameObject.Find("TheLevelContailner").transform.GetChild(0).gameObject);
            Instantiate(gameSettings.LevelPrefabs[level].gameObject, GameObject.Find("TheLevelContailner").transform);
            Player.position = gameSettings.playerDefaultPos;
            //save the progress
            int currenScore = UIController.instance.score;
            SaveController.instance.SaveGame(level, currenScore);
            UIController.instance.nextLevelUI.SetActive(false);
            UIController.instance.startUI.SetActive(true);

        }
        else
        {
            UIController.instance.winUI.SetActive(true);
        }
    }
    public void RestartLevel()
    {
        if (File.Exists(Application.persistentDataPath + "/Picker3D.save"))
        {
            Save saveFile = SaveController.instance.LoadGameSave();
            PlayerControler.instance.collectedBallCounter = 0;
            Destroy(GameObject.Find("TheLevelContailner").transform.GetChild(0).gameObject);
            Instantiate(gameSettings.LevelPrefabs[saveFile.currentlevel].gameObject, GameObject.Find("TheLevelContailner").transform);
            UIController.instance.score = saveFile.score;
            Player.position = gameSettings.playerDefaultPos;
            UIController.instance.loseUI.SetActive(false);
            UIController.instance.startUI.SetActive(true);
            return;
        }
        else
        {
            //because if save file doesnt created that mean player still first level
            UIController.instance.score = 0;
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
        PlayerControler.instance.collectedBallCounter = 0;
        Destroy(GameObject.Find("TheLevelContailner").transform.GetChild(0).gameObject);
        level++;
        Instantiate(gameSettings.LevelPrefabs[0].gameObject, GameObject.Find("TheLevelContailner").transform);
        Player.position = gameSettings.playerDefaultPos;
        UIController.instance.winUI.SetActive(false);
        UIController.instance.startUI.SetActive(true);
        UIController.instance.score = 0;
    }
}
