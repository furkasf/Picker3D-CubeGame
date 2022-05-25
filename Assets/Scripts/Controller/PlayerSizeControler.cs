using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerSizeControler : MonoBehaviour
{
    public static PlayerSizeControler instance;
    Vector3 orginalSize;
    public bool bigger;

    private void Awake()
    {
        orginalSize = transform.localScale;
        bigger = false;
        if(instance == null) instance = this;
    }

    public void IncreaseSizeOfPlayer()
    {
        transform.DOScale(new Vector3(transform.localScale.x + 0.7f, transform.localScale.y, transform.localScale.z), 0.7f);
        bigger = true;
    }

    public void ReturnOrginalSize()
    {
        transform.DOScale(orginalSize, 0.2f);
        bigger = false;
    }
}
