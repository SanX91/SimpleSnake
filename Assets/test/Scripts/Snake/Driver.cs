using UnityEngine;

namespace SimpleSnake
{
    /// <summary>
    /// The Driver class.
    /// This class is responsible for the movement and turning calculations of the snake.
    /// The snake gameobject just follows this driver smoothly -> The movement is exact, just the turning is smoothed out.
    /// </summary>
    public class Driver : MonoBehaviour
    {
        private SnakeSettings settings;
        private BoxCollider gridCollider;
        private IController controller;

        public void Initialize(SnakeSettings settings, BoxCollider gridCollider, IController controller)
        {
            this.settings = settings;
            this.gridCollider = gridCollider;
            this.controller = controller;
        }

        /// <summary>
        /// The driver moves forward automatically.
        /// It's restricted within the grid bounds.
        /// Whenever it reaches a dead end, it calculates a reflection vector from that point, and turns towards that vector instantly.
        /// It rotates itself based on input from the user.
        /// </summary>
        public void OnUpdate()
        {
            Vector3 position = transform.position;
            position += transform.forward * settings.speed * Time.deltaTime;
            float xPos = Mathf.Clamp(position.x, gridCollider.bounds.min.x, gridCollider.bounds.max.x);
            float zPos = Mathf.Clamp(position.z, gridCollider.bounds.min.z, gridCollider.bounds.max.z);

            if (!gridCollider.bounds.Contains(position))
            {
                Vector3 normal = GetNormal(gridCollider.bounds, position);
                Vector3 reflect = Vector3.Reflect(transform.forward, normal);
                transform.forward = reflect;
            }

            position = new Vector3(xPos, position.y, zPos);

            float horizontal = controller.HorizontalAxis();
            transform.Rotate(Vector3.up, horizontal * settings.turnSpeed * Time.deltaTime);

            transform.position = position;
        }

        /// <summary>
        /// Gets a normal vector from the grid edges, necessary for calculating a reflection vector.
        /// </summary>
        /// <param name="bounds"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        private Vector3 GetNormal(Bounds bounds, Vector3 position)
        {
            Vector3 center = bounds.center;
            Vector3 extents = bounds.extents;

            float xNormal = position.x > (center.x + bounds.extents.x) ? -1 : position.x < (center.x - bounds.extents.x) ? 1 : 0;
            float zNormal = position.z > (center.z + bounds.extents.z) ? -1 : position.z < (center.z - bounds.extents.z) ? 1 : 0;

            return new Vector3(xNormal, 0, zNormal);
        }
    }
}
