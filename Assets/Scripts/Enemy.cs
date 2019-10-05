using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //contador para calcular se o item deve ser aplicado ao inimigo ou não
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
        //quando um item é colocado sobre o inimigo e permanece por mais de meio segundo, sua utilização é confirmada na função invoke
        timer = 0.0f;
        Invoke("ApplyItem",0.5f);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        timer = 1f;
    }
    private void ApplyItem()
    {
        if (timer < 0.6f) {
            //o item foi aplicado
            //TODO: APLICAR EFEITO VISUAL
        }
    }
}
