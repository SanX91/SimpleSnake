using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    float speed = 5;
    float turnSpeed = 10;
    BoxCollider gridBounds;
    IController controller;

    public void Initialize(float speed, float turnSpeed, BoxCollider gridBounds, IController controller)
    {
        this.speed = speed;
        this.turnSpeed = turnSpeed;
        this.gridBounds = gridBounds;
        this.controller = controller;
    }

    public void OnUpdate()
    {
        Vector3 position = transform.position;
        position += transform.forward * speed * Time.deltaTime;
        float xPos = Mathf.Clamp(position.x, gridBounds.bounds.min.x, gridBounds.bounds.max.x);
        float zPos = Mathf.Clamp(position.z, gridBounds.bounds.min.z, gridBounds.bounds.max.z);

        if (!gridBounds.bounds.Contains(position))
        {
            Vector3 normal = GetNormal(gridBounds.bounds, position);
            Vector3 reflect = Vector3.Reflect(transform.forward, normal);
            transform.forward = reflect;
        }

        position = new Vector3(xPos, position.y, zPos);

        float horizontal = controller.HorizontalAxis();
        transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);

        transform.position = position;
    }

    Vector3 GetNormal(Bounds bounds, Vector3 position)
    {
        Vector3 center = bounds.center;
        Vector3 extents = bounds.extents;

        float xNormal = position.x > (center.x + bounds.extents.x) ? -1 : position.x < (center.x - bounds.extents.x) ? 1 : 0;
        float zNormal = position.z > (center.z + bounds.extents.z) ? -1 : position.z < (center.z - bounds.extents.z) ? 1 : 0;

        return new Vector3(xNormal, 0, zNormal);
    }
}
