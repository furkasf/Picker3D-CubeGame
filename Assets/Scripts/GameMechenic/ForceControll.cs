using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceControll : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        EventController.instance.PushCollectableItemEvent += PushAllCollectedItem;
    }

    void PushAllCollectedItem()
    {

        if (transform.tag == "Collected")
        {
            rb.AddForce(Vector3.forward * 10, ForceMode.Impulse);
        }
        
    }

    private void OnDestroy()
    {
        EventController.instance.PushCollectableItemEvent -= PushAllCollectedItem;
        //avtive paticul effect
    }
}
