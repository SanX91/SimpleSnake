using UnityEngine;
using UnityEngine.EventSystems;

namespace SimpleSnake
{
    /// <summary>
    /// The Game Controller UI class which implements the IController interface.
    /// The user controls the slider by dragging it, either left or right.(Horizontal axis)
    /// </summary>
    public class GameControllerUI : MonoBehaviour, IDragHandler, IEndDragHandler, IController
    {
        public RectTransform slider;
        private Vector3 initPosition;
        private Quaternion initRotation;
        private float horizontalAxis;

        private void Start()
        {
            initPosition = slider.transform.position;
            initRotation = slider.transform.rotation;
        }

        public void OnDrag(PointerEventData eventData)
        {
            UpdateHorizontalAxis(eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            slider.transform.position = initPosition;
            slider.transform.rotation = initRotation;

            horizontalAxis = 0;
        }

        private void UpdateHorizontalAxis(PointerEventData eventData)
        {
            Vector3 targetDir = (eventData.position - (Vector2)slider.transform.position).normalized;

            if (targetDir.y < 0)
            {
                targetDir = new Vector3(Mathf.Sign(targetDir.x), 0, targetDir.z);
            }

            slider.transform.rotation = Quaternion.FromToRotation(Vector3.up, targetDir);
            horizontalAxis = targetDir.x;
        }

        public float HorizontalAxis()
        {
            return horizontalAxis;
        }
    }
}
