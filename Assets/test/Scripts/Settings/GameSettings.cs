using UnityEngine;

namespace SimpleSnake
{
    /// <summary>
    /// The settings or prefabs required to setup the game.
    /// </summary>
    [CreateAssetMenu(fileName = "GameSettings", menuName = "SimpleSnake/Game settings")]
    public class GameSettings : ScriptableObject
    {
        public GridSystem gridSystem;
        public Snake snake;
        public CollectibleGenerator collectibleGenerator;
    }
}
