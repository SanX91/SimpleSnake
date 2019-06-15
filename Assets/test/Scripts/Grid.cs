using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
