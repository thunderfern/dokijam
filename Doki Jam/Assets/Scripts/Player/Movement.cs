using UnityEngine;
using Alteruna;

public class Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    private Rigidbody rb;
    private GameHost gh;
    private bool isGrounded = false;
    private Animator anim;

    private Vector3 OriginalCollider = new Vector3(0.769214f, 0.9256309f, 1f);
    private Vector3 SquatCollider = new Vector3(0.769214f, 0.7905512f, 1f);

    private Vector3 OriginalColliderPosition = new Vector3(-0.01795003f, 0.2757057f, 0f);
    private Vector3 SquatColliderPosition = new Vector3(-0.01795003f, 0.2081659f, 0f);

    BoxCollider coll;

    private Alteruna.Avatar _avatar;

    public bool isMultiplayer;

    int velocityWithAdded;

    void Start()
    {
        _avatar = GetComponent<Alteruna.Avatar>();

        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        coll = GetComponent<BoxCollider>();
        gh = GameObject.FindGameObjectWithTag("GameHost").GetComponent<GameHost>(); ;

        velocityWithAdded = 0;

        //if (isMultiplayer && !_avatar.IsMe) return;
        
    }

    void Update()
    {
        if (isMultiplayer && !_avatar.IsMe) return;
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("isSquatting", false);
            coll.size = OriginalCollider;
            coll.center = OriginalColliderPosition;
        }

        if (transform.position.y < -100f)
        {
            if (!gh.completed)
            {
                rb.linearVelocity = new Vector3(0, 0, 0);
                transform.position = gh.spawnPoint.position;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMultiplayer && !_avatar.IsMe) return;

        float horizontalInput = Input.GetAxis("Horizontal");

        float excessVelocity = rb.linearVelocity.x;

        if (excessVelocity < speed * -1 || excessVelocity > speed) excessVelocity -= speed * velocityWithAdded;
        //Debug.Log(excessVelocity);
        excessVelocity *= 0.95f;

        if (Input.GetAxis("Horizontal") > 0.01f)
        {
            velocityWithAdded = 1;
            rb.linearVelocity = new Vector3(speed + excessVelocity, rb.linearVelocity.y, rb.linearVelocity.z);
        }
        else if (Input.GetAxis("Horizontal") < -0.01f)
        {
            velocityWithAdded = -1;
            rb.linearVelocity = new Vector3(-1f * speed + excessVelocity, rb.linearVelocity.y, rb.linearVelocity.z);
        }
        else
        {
            velocityWithAdded = 0;
            rb.linearVelocity = new Vector3(excessVelocity, rb.linearVelocity.y, rb.linearVelocity.z);
        }
        //Debug.Log(excessVelocity);
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) && isGrounded)
        {
            rb.linearVelocity = rb.linearVelocity + new Vector3(0, jump, 0);
            isGrounded = false;
            anim.SetBool("isJumping", true);

        }

        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isSquatting", true);
            coll.size = SquatCollider;
            coll.center = SquatColliderPosition;

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
    private void OnCollisionEnter(Collision other)
    {
        if (isMultiplayer && !_avatar.IsMe) return;
        if ((other.gameObject.tag == "Ground" || other.gameObject.tag == "chonkydragoon" || other.gameObject.tag == "eggdragoon" || other.gameObject.tag == "longdragoon" || other.gameObject.tag == "regulardragoon") && rb.linearVelocity.y < 0.01f)
        {
            isGrounded = true;
            anim.SetBool("isJumping", false);
        }
        if (other.gameObject.tag == "Flag")
        {
            GameObject gameHost = GameObject.FindGameObjectWithTag("GameHost");
            if (!gameHost.GetComponent<GameHost>().hasWinner)
            {
                GetComponent<AcessoryController>().win = true;
                GetComponent<AcessoryController>().loseCount = 0;
                gameHost.GetComponent<GameHost>().BroadcastRemoteMethod("updateWinner");
            }
            gameHost.GetComponent<GameHost>().completed = true;
            gameObject.SetActive(false);
        }
    }

    
}
