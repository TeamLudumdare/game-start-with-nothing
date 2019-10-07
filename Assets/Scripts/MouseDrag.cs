using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    private Vector3 mousePosition;
    private Rigidbody2D rb;
    private Vector2 direction;
    private Vector3 startPosition;
    private float moveSpeed = 100f;
    private string col;
    private bool itsColliding = false;
    private SpriteRenderer m_SpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButton(0))
        {
            rb.velocity = Vector2.zero;
            transform.position = startPosition;
        }
    }
    private void OnMouseUpAsButton()
    {
        if (itsColliding)
        {
            if (col == "Enemy")
            {
                Debug.Log("Inimigo recebeu item");
                Disable();
                //DestroySelf();
                //TODO:ENVIAR PARA SERVIDOR O ATAQUE E O PLAYER DE DESTINO
            }
            else if(col == "Center")
            {
                //TODO: ENVIAR PARA SERVIDOR O ITEM, AÇÃO GLOBAL
            }
        }    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        col = collision.gameObject.tag;
        itsColliding = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        itsColliding = false;
    }
    void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
    }
    private void DestroySelf()
    {
        Destroy(gameObject);
    }
    private void Disable()
    {
        m_SpriteRenderer.color = Color.grey;
    }

}
