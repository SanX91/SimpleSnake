public class PickupCollectibleEvent : IEvent
{
    public object GetData()
    {
        return true;
    }
}

public class UpdateCollectibleUIEvent : IEvent
{
    int count;

    public UpdateCollectibleUIEvent(int count)
    {
        this.count = count;
    }

    public object GetData()
    {
        return count;
    }
}