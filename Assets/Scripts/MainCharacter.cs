using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{

    public Rigidbody2D rb;

    public float moveSpeed, jumpPower = 5.0f;

    public bool isGrounded;
    public bool canJump = true;
    float moveX = 1.0f;

    public bool hasCover = true;
    public bool isCovered = false;
    public GameObject Cover;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void PlayerControls(){

        if (Input.GetKeyDown(KeyCode.Space)){

            canJump = true;

        }

        moveX = Input.GetAxis("Horizontal");
    }

    void Jump(){

        if (!isGrounded){
            return;
        }

        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        isGrounded = false;

    }

    void CoverEnable() {

        if (!Cover.GetComponent<SpriteRenderer>().enabled && !Cover.GetComponent<CircleCollider2D>().enabled) {

            isCovered = false;
        
        }


        if (hasCover) {
            if (Input.GetKeyUp(KeyCode.Keypad0)) {

                isCovered = true;
                hasCover = false;
                Cover.GetComponent<SpriteRenderer>().enabled = true;
                Cover.GetComponent<CircleCollider2D>().enabled = true;

            }
        }
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        if (canJump){
            Jump();
            canJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

 
    void Update()
    {
        PlayerControls();
        CoverEnable();
    }
}
