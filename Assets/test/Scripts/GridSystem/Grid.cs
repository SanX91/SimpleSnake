using UnityEngine;

namespace SimpleSnake
{
    /// <summary>
    /// The grid class.
    /// Represents a single grid in the grid system.
    /// Has pre-visit and post-visit renderers, because having a single renderer and changing it's color at runtime, would increase the number of draw calls.
    /// Here "visit" signifies whether the snake has travelled through this grid or not.
    /// </summary>
    public class Grid : MonoBehaviour
    {
        public MeshRenderer preVisitRenderer, postVisitRenderer;

        public void Initialize()
        {
            ToggleRenderers();
        }

        public void ToggleRenderers(bool isVisited = false)
        {
            preVisitRenderer.gameObject.SetActive(!isVisited);
            postVisitRenderer.gameObject.SetActive(isVisited);
        }
    }
}
