using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed = 500.0f;
    public float jumpForce = 100.0f;
    public float sprintModifier = 2.0f;
    public Camera player_camera;
    public Transform groundDetector;
    public LayerMask ground;
    private float baseFOV;
    private float FOVmodifier = 1.35f;
    private Rigidbody rb;
    float xInput;
    float zInput;
    float adjustSpeed;
    float adjustJumpForce;
    bool sprint;
    bool isSprinting;
    bool jump;
    bool isJumping;
    bool isGrounded;

    bool checkIfDead = false;
    // Start is called before the first frame update
    void Start()
    {
        baseFOV = player_camera.fieldOfView;
        //Camera.main.enabled = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        zInput = Input.GetAxisRaw("Vertical");

        sprint = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        jump = Input.GetKeyDown(KeyCode.Space);

        //Checks
        isGrounded = Physics.Raycast(groundDetector.position, Vector3.down, 0.1f, ground);
        isJumping = jump && isGrounded;
        isSprinting = sprint && zInput > 0 && !isJumping && isGrounded;
        
        //Movement
        Vector3 Movement = new Vector3(xInput, 0.0f, zInput);
        Movement.Normalize();

        //adjustSpeed = speed;
        if (Input.GetKeyDown(KeyCode.K) && checkIfDead == false)
        {
            rb.mass = 0.75f;
            checkIfDead = true;
        }
        adjustSpeed = speed;
        adjustJumpForce = jumpForce;
       
        Vector3 t_targetVelocity = transform.TransformDirection(Movement) * adjustSpeed * Time.deltaTime;
        t_targetVelocity.y = rb.velocity.y;
        rb.velocity = t_targetVelocity;
        

        //Jumping
        if (isJumping)
        {
            rb.AddForce(Vector3.up * adjustJumpForce);
            
        }
        
        //Camera when sprinting
        if (isSprinting) { player_camera.fieldOfView = Mathf.Lerp(player_camera.fieldOfView, baseFOV * FOVmodifier, Time.deltaTime * 8f); }
        else { player_camera.fieldOfView = Mathf.Lerp(player_camera.fieldOfView, baseFOV, Time.deltaTime * 8f); }

        
    }
}
