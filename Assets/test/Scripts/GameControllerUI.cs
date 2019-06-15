using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameControllerUI : MonoBehaviour, IDragHandler, IEndDragHandler, IController
{
    Vector3 initPosition;
    Quaternion initRotation;

    float horizontalAxis;

    void Start()
    {
        initPosition = transform.position;
        initRotation = transform.rotation;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 targetDir = (eventData.position - (Vector2)transform.position).normalized;

        if(targetDir.y<0)
        {
            targetDir = new Vector3(Mathf.Sign(targetDir.x), 0, targetDir.z);
        }
        
        transform.rotation = Quaternion.FromToRotation(Vector3.up, targetDir);
        horizontalAxis = targetDir.x;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = initPosition;
        transform.rotation = initRotation;

        horizontalAxis = 0;
    }

    public float HorizontalAxis()
    {
        return horizontalAxis;
    }
}
