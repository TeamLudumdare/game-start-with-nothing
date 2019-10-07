using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollParallaxClouds : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.5f;
    private Material m_Material;
    private float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 60f)
        {
            time = 0f;
        }
        time = Time.time;
        Vector2 offset = new Vector2(time * speed,1);
        m_Material = GetComponent<Renderer>().material;
        m_Material.mainTextureOffset = offset;
    }
}
