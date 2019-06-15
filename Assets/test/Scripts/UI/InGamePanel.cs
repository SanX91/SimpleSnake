using TMPro;
using UnityEngine;

namespace SimpleSnake
{
    /// <summary>
    /// The In Game UI panel.
    /// Currently, just updates the collectible text upon receiving the UpdateCollectibleUIEvent.
    /// </summary>
    public class InGamePanel : MonoBehaviour
    {
        public TextMeshProUGUI collectibleText;

        private void OnEnable()
        {
            EventManager.Instance.AddListener<UpdateCollectibleUIEvent>(OnUpdateCollectibleUIEvent);
        }

        private void OnDisable()
        {
            EventManager.Instance.RemoveListener<UpdateCollectibleUIEvent>(OnUpdateCollectibleUIEvent);
        }

        private void OnUpdateCollectibleUIEvent(UpdateCollectibleUIEvent evt)
        {
            collectibleText.SetText(evt.GetData().ToString());
        }
    }

}