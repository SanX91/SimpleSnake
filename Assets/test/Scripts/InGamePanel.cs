using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class InGamePanel : MonoBehaviour
{
    public TextMeshProUGUI collectibleText;

    private void OnEnable()
    {
        EventManager.Instance.AddListener<UpdateCollectibleUIEvent>(OnUpdateCollectibleUIEvent);
    }

    private void OnDisable()
    {
        EventManager.Instance.RemoveListener<UpdateCollectibleUIEvent>(OnUpdateCollectibleUIEvent);
    }

    private void OnUpdateCollectibleUIEvent(UpdateCollectibleUIEvent evt)
    {
        collectibleText.SetText(evt.GetData().ToString());
    }
}
