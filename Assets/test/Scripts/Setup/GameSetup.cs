using System.Collections;
using UnityEngine;

namespace SimpleSnake
{
    /// <summary>
    /// The Game Setup class.
    /// Generates a few sub modules from settings.
    /// This class is not really that necessary, but sometimes it can be used to initialize systems with common dependencies.
    /// </summary>
    public class GameSetup : MonoBehaviour
    {
        public GameSettings settings;
        public GameControllerUI controllerUI;
        private Snake snake;

        // Start is called before the first frame update
        private IEnumerator Start()
        {
            GridSystem gridSystem = Instantiate(settings.gridSystem, Vector3.zero, Quaternion.identity, transform);
            gridSystem.Initialize();
            yield return new WaitForSeconds(1);

            snake = Instantiate(settings.snake, Vector3.zero, Quaternion.identity, transform);
            snake.Initialize(gridSystem, controllerUI);
            yield return null;

            CollectibleGenerator collectibleGenerator = Instantiate(settings.collectibleGenerator, Vector3.zero, Quaternion.identity, transform);
            collectibleGenerator.Initialize(gridSystem);
        }

        private void Update()
        {
            if (snake == null)
            {
                return;
            }

            snake.OnUpdate();
        }

        private void LateUpdate()
        {
            if (snake == null)
            {
                return;
            }

            snake.OnLateUpdate();
        }
    } 
}
