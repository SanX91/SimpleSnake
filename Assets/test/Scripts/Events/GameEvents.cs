namespace SimpleSnake
{
    /// <summary>
    /// Event signifying a collectible pick up.
    /// </summary>
    public class PickupCollectibleEvent : IEvent
    {
        public object GetData()
        {
            return true;
        }
    }

    /// <summary>
    /// Event to update the collectible UI.
    /// </summary>
    public class UpdateCollectibleUIEvent : IEvent
    {
        private readonly int count;

        public UpdateCollectibleUIEvent(int count)
        {
            this.count = count;
        }

        public object GetData()
        {
            return count;
        }
    }
}