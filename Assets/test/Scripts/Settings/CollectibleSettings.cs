using UnityEngine;

namespace SimpleSnake
{
    /// <summary>
    /// Settings for generating collectibles at certain intervals.
    /// </summary>
    [CreateAssetMenu(fileName = "CollectibleSettings", menuName = "SimpleSnake/Collectible settings")]
    public class CollectibleSettings : ScriptableObject
    {
        public float stayTime = 4;
        public float generateTime = 6;
    }
}
