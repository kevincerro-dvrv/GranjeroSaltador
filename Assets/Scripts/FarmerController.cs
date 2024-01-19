using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerController : MonoBehaviour {
    private Rigidbody rb;
    private float jumpForce = 9f;
    private Animator animator;

    private bool pendingJump = false;
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update() {
        bool isGrounded = IsGrounded();
        

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded) {            
            pendingJump = true;
            animator.SetBool("Jump_b", true);
        }

        
    }


    void FixedUpdate() {
        if(IsGrounded() && rb.velocity.y < 0) {
           animator.SetBool("Jump_b", false);
        }
        if(pendingJump) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            pendingJump = false;
        }


    }

    private bool IsGrounded() {
        //return Physics.SphereCast(transform.position, 0.5f, Vector3.down, out RaycastHit hitInfo, 0.5f);
        return Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfo, 0.15f);
    }
}
