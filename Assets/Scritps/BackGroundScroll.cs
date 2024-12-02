using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    public Renderer render;

    public float scroll_speed = 1f;

    private void Awake()
    {
        render = GetComponent<Renderer>();
    }

    private void Update()
    {
        render.material.mainTextureOffset += new Vector2(0f, scroll_speed*Time.deltaTime);
    }
}
