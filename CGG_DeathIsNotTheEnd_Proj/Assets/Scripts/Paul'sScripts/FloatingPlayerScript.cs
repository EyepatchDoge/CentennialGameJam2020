using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 MovementV;
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        MovementV = moveInput.normalized * speed;

        //rb.MovePosition(rb.position + MovementV * Time.deltaTime);

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + MovementV * Time.fixedDeltaTime);
    }
}
