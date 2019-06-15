using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    public GridSystem gridSystem;
    public Snake snake;
    public CollectibleGenerator collectibleGenerator;
    public GameControllerUI controllerUI;

    // Start is called before the first frame update
    void Start()
    {
        gridSystem.Initialize();
        snake.Initialize(gridSystem, controllerUI);
        collectibleGenerator.Initialize(gridSystem);
    }

    void Update()
    {
        snake.OnUpdate();
    }

    private void LateUpdate()
    {
        snake.OnLateUpdate();
    }
}
