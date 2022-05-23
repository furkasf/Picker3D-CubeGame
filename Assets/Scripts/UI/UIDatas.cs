using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableOBJ/UIDatas", fileName = "UIDatas")]
public class UIDatas : ScriptableObject
{
    public GameObject winUI;
    public GameObject loseUI;
    public GameObject nextLevelUI;
    public GameObject startUI;
    public GameObject Score;
}
