using UnityEngine;

public interface IGridSystem
{
    BoxCollider GridCollider { get; }
    Vector3 CenterPoint();
    Vector3 RandomPoint();
}