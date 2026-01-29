using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveX;
    private bool isJumping;
    public float speed;
    public float jumpForce;
    private int scoreCount;
    public Text scoreUI;

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
            jumpForce = Random.Range(100,1000);
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
            scoreCount += 10;
            Debug.Log(scoreCount);
            scoreUI.text = "Score = " + scoreCount.ToString();
        } 
        else if(target.gameObject.CompareTag("Enemy"))
        {
            //make a player disappear
            //gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);//load this scene again
        }
    }
}
