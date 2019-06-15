using UnityEngine;

namespace SimpleSnake
{
    /// <summary>
    /// The Game Data class.
    /// Currently storing the number of collectibles picked up by the user.
    /// Listens to the PickupCollectibleEvent to stay updated on the collectible count.
    /// Dispatches an event to update the collectible UI on collectible count increment.
    /// </summary>
    public class GameData : MonoBehaviour
    {
        private int collectibles;

        private void OnEnable()
        {
            EventManager.Instance.AddListener<PickupCollectibleEvent>(OnPickupCollectibleEvent);
        }

        private void OnDisable()
        {
            EventManager.Instance.RemoveListener<PickupCollectibleEvent>(OnPickupCollectibleEvent);
        }

        private void Start()
        {
            EventManager.Instance.TriggerEvent(new UpdateCollectibleUIEvent(collectibles));
        }

        private void OnPickupCollectibleEvent(PickupCollectibleEvent evt)
        {
            collectibles++;
            EventManager.Instance.TriggerEvent(new UpdateCollectibleUIEvent(collectibles));
        }
    }
}
