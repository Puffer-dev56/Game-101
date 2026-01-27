using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveX;
    private bool isJumping;
    public float speed;
    public float jumpForce;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveX * speed,rb.linearVelocity.y);
        if (Input.GetButtonDown("Jump") && !isJumping) {
            rb.AddForce(new Vector2(rb.linearVelocity.x, jumpForce)); 
        }
    }

    //Checked Player on ground
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("Ground")) {
            isJumping = false;
        }
    }
    private void OnCollisionExit2D(Collision2D target) 
    {
        if (target.gameObject.CompareTag("Ground")) { 
            isJumping = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Item"))
        {
            Destroy(target.gameObject);
        }
    }
}
