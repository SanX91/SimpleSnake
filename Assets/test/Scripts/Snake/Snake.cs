using UnityEngine;

namespace SimpleSnake
{
    /// <summary>
    /// The Snake class.
    /// Instantiates and initializes a Driver class, which takes care of all the movement and turning calculations.
    /// This gameobject just follows the Driver gameobject with some smoothness.(Only the rotation)
    /// Also detects trigger entries of itself with grids and collectibles.
    /// </summary>
    public class Snake : MonoBehaviour
    {
        public Driver driverPrefab;
        public SnakeSettings settings;
        private IGridSystem gridSystem;
        private Driver driver;

        public void Initialize(IGridSystem gridSystem, IController controller)
        {
            this.gridSystem = gridSystem;

            transform.position = gridSystem.CenterPoint();
            driver = Instantiate(driverPrefab, transform.position, transform.rotation);
            driver.Initialize(settings, gridSystem.GridCollider, controller);
        }

        public void OnUpdate()
        {
            if (driver == null)
            {
                return;
            }

            driver.OnUpdate();
        }

        /// <summary>
        /// Snaps to the Driver's position.
        /// Rotates smoothly to look at the Driver.
        /// </summary>
        public void OnLateUpdate()
        {
            if (driver == null)
            {
                return;
            }

            transform.position = driver.transform.position;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, driver.transform.rotation, settings.turnSpeed * Time.deltaTime);
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
            if (collectible != null)
            {
                collectible.OnCollect();
            }
        }
    }
}
