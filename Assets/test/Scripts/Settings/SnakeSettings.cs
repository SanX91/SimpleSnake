using UnityEngine;

namespace SimpleSnake
{
    /// <summary>
    /// Snake related settings related to movement or rotation.
    /// </summary>
    [CreateAssetMenu(fileName = "SnakeSettings", menuName = "SimpleSnake/Snake settings")]
    public class SnakeSettings : ScriptableObject
    {
        public float speed = 10;
        public float turnSpeed = 80;
    }
}
