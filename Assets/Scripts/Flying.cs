using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flying : MonoBehaviour
{
    public float moveSpeed, flyForce = 1.0f;
    public Rigidbody2D rb;

    public bool hasCover = true;
    public bool isCovered = false;
    public GameObject Cover;

    public bool canFly = false;
    public bool simpleMove = false;

    public float jumpPower = 5.0f;
    public bool isGrounded;
    public bool canJump = false;
    float moveX = 1.0f;

    float timer = 0;
    bool begintimer = true;

    public bool withBook = false;
    public bool toChamber = false;
    public bool respond = false;

    public float respondTimer = 0;
    public GameObject GhostText2;
    public GameObject respondText;
    public GameObject GhostText3;

    public bool beginRespond = false;
    public bool preSelection = false;
    public bool selection = false;

    public Animator animator;

    void Start()
    {
        respondText.SetActive(false);
        GhostText3.SetActive(false);

        animator = GetComponent<Animator>();
        animator.SetBool("isFly", true);
    }

    void Fly() {
        if (Input.GetKeyUp(KeyCode.Space)) {
            rb.velocity = Vector2.up * flyForce;
        }
    }
    void PlayerControls()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            canJump = true;

        }

        moveX = Input.GetAxis("Horizontal");
        animator.SetFloat("MoveX", moveX);
    }

    private void FixedUpdate()
    {
        if (!simpleMove)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

            if (canJump)
            {
                Jump();
                canJump = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
            isGrounded = true;
    }

    void Jump()
    {

        if (!isGrounded)
        {
            return;
        }

        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        isGrounded = false;

    }

    void CoverEnable()
    {

        if (!Cover.GetComponent<SpriteRenderer>().enabled && !Cover.GetComponent<CircleCollider2D>().enabled)
        {

            isCovered = false;

        }


        if (hasCover)
        {
            if (Input.GetKeyUp(KeyCode.Keypad0))
            {

                isCovered = true;
                hasCover = false;
                Cover.GetComponent<SpriteRenderer>().enabled = true;
                Cover.GetComponent<CircleCollider2D>().enabled = true;

            }
        }
    }

    void Update()
    {
        CoverEnable();
        if (begintimer)
        {
            timer += Time.deltaTime;
            if (timer > 3)
            {
                canFly = true;
                begintimer = false;
            }
        }
        

        if (!canFly && !simpleMove) {
            rb.bodyType = RigidbodyType2D.Static;
        }

        if (canFly)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            animator.SetBool("isFly", true);
            Fly();
        }

        if (simpleMove) {
            PlayerControls();
            animator.SetBool("isFly", false);
        }

        if (respond) {
            simpleMove = false;
            if(beginRespond){
                if (Input.GetKeyUp(KeyCode.Return))
                {
                    GhostText2.SetActive(false);
                    respondText.SetActive(true);
                    preSelection = true;
                }
            }
            if (preSelection) {
                if(Input.GetKeyDown(KeyCode.Return)) {
                    beginRespond = false;
                    respondText.SetActive(false);
                    GhostText3.SetActive(true);
                    selection = true;
                }
            }
        }

        if (selection) {
            if (Input.GetKeyUp(KeyCode.G)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            if (Input.GetKeyUp(KeyCode.P))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            }
        }
    }
}
