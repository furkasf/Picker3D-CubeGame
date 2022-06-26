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


    #region Subscriptions
    private void OnEnable() => SubscribeEvent();
    private void OnDisable() => DeSubscribeEvent();
    private void SubscribeEvent() => EventController.instance.PushCollectableItemEvent += OnPushAllCollectedItem;
    private void DeSubscribeEvent() => EventController.instance.PushCollectableItemEvent -= OnPushAllCollectedItem;
    #endregion

    private void OnPushAllCollectedItem()
    {

        if (transform.tag == "Collected")
        {
            rb.AddForce(Vector3.forward * 15, ForceMode.Impulse);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.other.CompareTag("Road"))
        {
            if(gameObject.tag != "Collected")
            {
                rb.isKinematic = true;
            }
        }
    }

}
