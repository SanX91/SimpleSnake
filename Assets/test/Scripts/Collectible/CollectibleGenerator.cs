using System.Collections;
using UnityEngine;

namespace SimpleSnake
{
    /// <summary>
    /// The Collectible Generator class.
    /// Can generate any type of collectible.
    /// Currently generates just one collectible over and over throughout the game cycle.
    /// </summary>
    public class CollectibleGenerator : MonoBehaviour
    {
        public GameObject collectible;
        public CollectibleSettings settings;
        private IGridSystem gridSystem;
        private Coroutine deactivateCollectible;

        /// <summary>
        /// Instatiates a single collectible object.
        /// Invokes the "GenerateCollectible" method, after a certain interval, over and over.
        /// </summary>
        /// <param name="gridSystem"></param>
        public void Initialize(IGridSystem gridSystem)
        {
            this.gridSystem = gridSystem;

            collectible = Instantiate(collectible, transform);
            collectible.SetActive(false);

            InvokeRepeating("GenerateCollectible", settings.generateTime, settings.generateTime);
        }

        /// <summary>
        /// Activates the collectible and positions it on a random grid location.
        /// </summary>
        private void GenerateCollectible()
        {
            if (deactivateCollectible != null)
            {
                StopCoroutine(deactivateCollectible);
            }

            collectible.transform.position = gridSystem.RandomPoint();
            collectible.SetActive(true);

            deactivateCollectible = StartCoroutine(DeactivateCollectible());
        }

        private IEnumerator DeactivateCollectible()
        {
            yield return new WaitForSeconds(settings.stayTime);
            collectible.SetActive(false);
        }
    }
}
