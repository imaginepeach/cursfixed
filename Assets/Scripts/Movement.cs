using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    [SerializeField] private BoxCollider groundedBox;

    public float jumpForce;
    public float jumpCooldown;
    private float jumpCooldownLeft;
    public float airMultiplier;
    private int jumpAmount = 2;
    private int jumpLeft = 2;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space; 

    [Header("Ground Check")]
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public void ChangeGround(bool value)
    { 
        grounded = value;

        if (grounded)
        {
            ResetJump();
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
        SpeedControl();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if(Input.GetKey(jumpKey) && jumpLeft > 0 && jumpCooldownLeft <= 0)
        {
            jumpCooldownLeft = jumpCooldown;

            Jump();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        jumpCooldownLeft -= Time.deltaTime;

        MyInput();

        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
            rb.drag = 0;
    }

    private void MovePlayer()
    {
        transform.rotation = orientation.rotation;
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerClass>().SpeedMult * 10f, ForceMode.Force);
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerClass>().SpeedMult * 10f*airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
    private void Jump()
    {
        jumpLeft--;
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        jumpLeft = jumpAmount;
    }
}
