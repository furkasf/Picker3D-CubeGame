using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceControll : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] int ID;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        EventController.instance.PushCollectableItemEvent += PushAllCollectedItem;
    }

    void PushAllCollectedItem(int ID)
    {
        if(ID == this.ID)
        {
            if (transform.tag == "Collectable")
            {
                rb.AddForce(Vector3.forward * 10, ForceMode.Impulse);
            }
        }
    }

    private void OnDestroy()
    {
        EventController.instance.PushCollectableItemEvent -= PushAllCollectedItem;
    }
}
