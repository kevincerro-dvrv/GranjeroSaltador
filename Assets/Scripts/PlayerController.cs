using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 6;
    private Rigidbody rb;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isGrounded = IsGrounded();
        Debug.Log(isGrounded);

        if (isGrounded & rb.velocity.y < 0) {
            animator.SetBool("Jump_b", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) & isGrounded) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetBool("Jump_b", true);
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.zero, Vector3.down, out RaycastHit hitInfo, 0.1f);
    }
}
