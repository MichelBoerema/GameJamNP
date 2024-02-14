using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScrolling : MonoBehaviour
{
    public float scrollSpeedX = 0.5f;
    public float scrollSpeedY = 0.5f;

    void Update()
    {
        float offsetX = Time.time * scrollSpeedX;
        float offsetY = Time.time * scrollSpeedY;

        Renderer renderer = GetComponent<Renderer>();
        Material[] materials = renderer.materials;

        foreach (Material material in materials)
        {
            material.mainTextureOffset = new Vector2(offsetX, offsetY);
        }
    }
}
