using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject item;
    private float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        timer = 0.0f;
        item = collision.GetComponent<GameObject>();
        Invoke("ApplyItem",0.5f);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        timer = 1f;
    }
    private void ApplyItem()
    {
        if (timer < 0.9f) {
            //o item foi aplicado
            //TODO: APLICAR EFEITO VISUAL
        }
    }
}
