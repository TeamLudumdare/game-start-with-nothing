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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
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
    void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
    }

}
