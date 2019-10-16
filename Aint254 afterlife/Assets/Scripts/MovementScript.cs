using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementScript : MonoBehaviour
{
    public float speed = 500.0f;
    public float jumpForce = 100.0f;
    public float sprintModifier = 2.0f;
    public Camera player_camera;
    public Transform groundDetector;
    public LayerMask ground;
    public GameObject barTime;
    private float baseFOV;
    private float FOVmodifier = 1.35f;
    private Rigidbody rb;
    private Transform HUD_time;
    float xInput;
    float zInput;
    float adjustSpeed;
    float adjustJumpForce;
    float maxTime = 150.0f;
    float minusTime = 10.0f;
    float remainTime = 150.0f;
    bool sprint;
    bool isSprinting;
    bool jump;
    bool isJumping;
    bool isGrounded;
    
    public Return rs;
    bool checkIfDead = false;
    bool checkRange = false;
    // Start is called before the first frame update
    void Start()
    {
        baseFOV = player_camera.fieldOfView;
        //Camera.main.enabled = false;
        rb = GetComponent<Rigidbody>();
        HUD_time = GameObject.Find("HUD/Time/Bar").transform;
        barTime.transform.gameObject.SetActive(false);
        
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

        CheckIfDeaded();
        adjustSpeed = speed;
        adjustJumpForce = jumpForce;
       
        Vector3 t_targetVelocity = transform.TransformDirection(Movement) * adjustSpeed * Time.deltaTime;
        t_targetVelocity.y = rb.velocity.y;
        rb.velocity = t_targetVelocity;

        if (Input.GetKeyDown(KeyCode.U))
        {
            //UpdateHealth();
            //barTime.transform.gameObject.SetActive(true);
            //InvokeRepeating("UpdateTime", 0.0f, 1.0f);
        }
        //Jumping
        if (isJumping)
        {
            rb.AddForce(Vector3.up * adjustJumpForce);
        }
        
        //Camera when sprinting
        if (isSprinting) { player_camera.fieldOfView = Mathf.Lerp(player_camera.fieldOfView, baseFOV * FOVmodifier, Time.deltaTime * 8f); }
        else { player_camera.fieldOfView = Mathf.Lerp(player_camera.fieldOfView, baseFOV, Time.deltaTime * 8f); }
    }
    void CheckIfDeaded()
    {
        if (Input.GetKeyDown(KeyCode.K) && checkIfDead == false)
        {
            rb.mass = 0.75f;
            checkIfDead = true;
            barTime.transform.gameObject.SetActive(true);
            InvokeRepeating("UpdateTime", 0.0f, 1.0f);
        }

        if (Input.GetKeyDown(KeyCode.K) && checkIfDead == true)
        {
            if (rs.rangeCheck == true)
            {
                checkRange = true;
            }
            if (checkRange == true)
            {
                rb.mass = 1.0f;
                checkIfDead = false;
                checkRange = false;
                barTime.transform.gameObject.SetActive(false);
                CancelInvoke();
                remainTime = maxTime;
            }
        }
    }
    void UpdateTime()
    {
        if (remainTime <= 10)
        {
            FindObjectOfType<sceneLoader>().LoadGameOver();
        }
        remainTime -= minusTime;
        float t_time = (float)remainTime / (float)maxTime;
        HUD_time.localScale = new Vector3(t_time, 1, 1);
        
    }
}
