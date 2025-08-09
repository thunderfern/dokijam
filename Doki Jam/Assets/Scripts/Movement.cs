using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float speed = 5;
    [SerializeField] private float jump = 5;
    private Rigidbody rb;
    private bool isGrounded = false;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = rb.linearVelocity + new Vector3(Input.GetAxis("Horizontal") * speed, rb.linearVelocity.y, rb.linearVelocity.z);
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) && isGrounded)
        {
            Debug.Log("uhh");
            rb.linearVelocity = rb.linearVelocity + new Vector3(rb.linearVelocity.x, jump, rb.linearVelocity.z);
            isGrounded = false;
            anim.SetBool("isJumping", true);
        }

        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isSquatting", true);

        }

        if (Input.GetKeyUp(KeyCode.S)){
            anim.SetBool("isSquatting", false);

        }



        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        anim.SetBool("isRunning", horizontalInput != 0);

    }
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
            anim.SetBool("isJumping", false);
        }
    }
}
