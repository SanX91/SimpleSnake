using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public void OnCollect()
    {
        EventManager.Instance.TriggerEvent(new PickupCollectibleEvent());
        gameObject.SetActive(false);
    }
}
