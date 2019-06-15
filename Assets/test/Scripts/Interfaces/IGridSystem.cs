using UnityEngine;

namespace SimpleSnake
{
    /// <summary>
    /// An interface which exposes some properties and methods useful for a Grid System.
    /// </summary>
    public interface IGridSystem
    {
        BoxCollider GridCollider { get; }
        Vector3 CenterPoint();
        Vector3 RandomPoint();
    }
}