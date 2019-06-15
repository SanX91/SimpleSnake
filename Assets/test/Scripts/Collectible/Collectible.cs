using UnityEngine;

namespace SimpleSnake
{
    /// <summary>
    /// The collectible class.
    /// Can be any type of collectible, which triggers an event upon pickup.
    /// </summary>
    public class Collectible : MonoBehaviour
    {
        public void OnCollect()
        {
            EventManager.Instance.TriggerEvent(new PickupCollectibleEvent());
            gameObject.SetActive(false);
        }
    }
}
