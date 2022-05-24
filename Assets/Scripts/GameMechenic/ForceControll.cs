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
        if(gameObject != null)
            EventController.instance.PushCollectableItemEvent += PushAllCollectedItem;
    }

    void PushAllCollectedItem()
    {

        if (transform.tag == "Collected")
        {
            rb.AddForce(Vector3.forward * 15, ForceMode.Impulse);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Road")
        {
            if(gameObject.tag != "Collected")
            {
                rb.isKinematic = true;
            }
        }
    }

    private void OnDestroy()
    {
        if(gameObject != null)
            EventController.instance.PushCollectableItemEvent -= PushAllCollectedItem;
        //avtive paticul effect
    }
}
