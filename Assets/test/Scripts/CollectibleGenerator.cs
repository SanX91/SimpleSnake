using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleGenerator : MonoBehaviour
{
    public GameObject collectible;
    public float stayTime = 4;
    public float generateTime = 10;
    IGridSystem gridSystem;

    Coroutine deactivateCollectible;

    public void Initialize(IGridSystem gridSystem)
    {
        this.gridSystem = gridSystem;

        collectible = Instantiate(collectible);
        collectible.SetActive(false);

        InvokeRepeating("GenerateCollectible", generateTime, generateTime);
    }

    void GenerateCollectible()
    {
        if(deactivateCollectible!=null)
        {
            StopCoroutine(deactivateCollectible);
        }

        collectible.transform.position = gridSystem.RandomPoint();
        collectible.SetActive(true);

        deactivateCollectible = StartCoroutine(DeactivateCollectible());
    }

    IEnumerator DeactivateCollectible()
    {
        yield return new WaitForSeconds(stayTime);
        collectible.SetActive(false);
    }
}
