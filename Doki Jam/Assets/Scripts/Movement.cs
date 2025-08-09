using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float speed = 5;
    [SerializeField] private float jump = 5;
    private Rigidbody rb;
    private bool isGrounded = false;
    private Animator anim;

    [SerializeField] private Vector3 OriginalCollider = new Vector3(0.769214f, 0.9256309f, 1f);
    [SerializeField] private Vector3 SquatCollider = new Vector3(0.769214f, 0.7905512f, 1f);

    [SerializeField] private Vector3 OriginalColliderPosition = new Vector3(-0.01795003f, 0.2757057f, 0f);
    [SerializeField] private Vector3 SquatColliderPosition = new Vector3(-0.01795003f, 0.2081659f, 0f);

    BoxCollider coll;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        coll = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector3(Mathf.Max(Mathf.Min(Input.GetAxis("Horizontal") * speed + rb.linearVelocity.x, 3.0f), -3.0f), rb.linearVelocity.y, rb.linearVelocity.z);
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) && isGrounded)
        {
            Debug.Log("uhh");
            rb.linearVelocity = rb.linearVelocity + new Vector3(0, jump, 0);
            isGrounded = false;
            anim.SetBool("isJumping", true);
        
        }

        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isSquatting", true);
            Debug.Log("hold");
            coll.size = SquatCollider;
            coll.center= SquatColliderPosition;


        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("isSquatting", false);
            Debug.Log("Letgo");
            coll.size = OriginalCollider;
            coll.center = OriginalColliderPosition;


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
