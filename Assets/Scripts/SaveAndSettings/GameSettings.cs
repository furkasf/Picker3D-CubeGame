using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableOBJ/GameSettings", fileName = "GameSetting")]
public class GameSettings : ScriptableObject
{
    public Vector3 playerDefaultPos;
    public List<GameObject> LevelPrefabs;
}
