using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    int collectibles;

    private void OnEnable()
    {
        EventManager.Instance.AddListener<PickupCollectibleEvent>(OnPickupCollectibleEvent);
    }

    private void OnDisable()
    {
        EventManager.Instance.RemoveListener<PickupCollectibleEvent>(OnPickupCollectibleEvent);
    }

    private void Start()
    {
        EventManager.Instance.TriggerEvent(new UpdateCollectibleUIEvent(collectibles));
    }

    private void OnPickupCollectibleEvent(PickupCollectibleEvent evt)
    {
        collectibles++;
        EventManager.Instance.TriggerEvent(new UpdateCollectibleUIEvent(collectibles));
    }
}
