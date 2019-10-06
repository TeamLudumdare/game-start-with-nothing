using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollParallaxClouds : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.5f;
    private Material m_Material;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(Time.time *speed,0);
        m_Material = GetComponent<Renderer>().material;
        m_Material.mainTextureOffset = offset;
    }
}
