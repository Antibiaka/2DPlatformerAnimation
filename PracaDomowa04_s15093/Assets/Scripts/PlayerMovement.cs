using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed = 5;
    public float jumpForce = 300;
    private Rigidbody2D rb;
    private Animator animator;
    private float xDisplacement;
    public Collider2D stayingCol;

    private bool isJumping;
    public bool isCrouch;
    
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update() {
        xDisplacement = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector2(xDisplacement, rb.velocity.y);

        if (xDisplacement < 0) {
            transform.eulerAngles = new Vector3(0, 180, 0);
        } else if (xDisplacement > 0) {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (Input.GetButtonDown("Jump") && !isJumping) //jump and test @on ground@
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
            isJumping = true;
        }

        Crouch();


        StartAnimation();
    }

    void Crouch() {

        if (Input.GetKeyDown(KeyCode.LeftControl) && !isCrouch && !isJumping) {
            stayingCol.enabled = false;
            isCrouch = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl) && !isJumping) {
            isCrouch = false;
            stayingCol.enabled = true;
        }
    }

    
    void OnCollisionEnter2D(Collision2D col) {

        if (col.gameObject.CompareTag("Ground")) {
            isJumping  = false;
        }
      }
    
   


    void StartAnimation() {
        animator.SetFloat("Movement", Mathf.Abs(xDisplacement));
        animator.SetBool("isJumping", isJumping);
        animator.SetBool("isCrouch", isCrouch);
    }
}