using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 MovementV;
    public float speed = 10;
    bool facingLeft;

    public FloatingPlayerScript floatingP;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        floatingP = GetComponent<FloatingPlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        MovementV = moveInput.normalized * speed;

        if (MovementV.x > 0.0f)
        {
            if (facingLeft) Flip();
        }
        else if (MovementV.x < 0.0f)
        {
            if (!facingLeft) Flip();
        }
    }

    public void Flip()
    {
        facingLeft = !facingLeft;
        transform.Rotate(0f, 180f, 0f);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + MovementV * Time.fixedDeltaTime);
    }

    public void PauseCharacter()
    {
        floatingP.enabled = false;
        Debug.Log("Player has stopped moving");
    }

    public void MoveCharacter()
    {
        floatingP.enabled = true;
        Debug.Log("Player has continued moving");
    }
}
