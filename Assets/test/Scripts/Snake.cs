using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public Driver driver;
    public float speed = 5;
    public float turnSpeed = 10;
    public float gridUpdateRadius = 10;

    IGridSystem gridSystem;

    public void Initialize(IGridSystem gridSystem, IController controller)
    {
        this.gridSystem = gridSystem;

        transform.position = gridSystem.CenterPoint();
        driver = Instantiate(driver, transform.position, transform.rotation);
        driver.Initialize(speed, turnSpeed, gridSystem.GridCollider, controller);
    }

    public void OnUpdate()
    {
        driver.OnUpdate();
    }

    public void OnLateUpdate()
    {
        transform.position = driver.transform.position;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, driver.transform.rotation, turnSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Grid grid = other.GetComponent<Grid>();
        if (grid != null)
        {
            grid.ToggleRenderers(true);
            return;
        }

        Collectible collectible = other.GetComponent<Collectible>();
        if (collectible!=null)
        {
            collectible.OnCollect();
        }
    }
}
