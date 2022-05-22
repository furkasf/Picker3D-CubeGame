using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameObject UI;
    public GameSettings gameSettings;
    public Transform Player;
    int level = 0;

    public void NextLevel()
    {
        Destroy(GameObject.Find("TheLevelContailner").transform.GetChild(0).gameObject);
        level++;
        Instantiate(gameSettings.LevelPrefabs[level].gameObject, GameObject.Find("TheLevelContailner").transform);
        Player.position = gameSettings.playerDefaultPos;
        UI.SetActive(false);
    }
}
