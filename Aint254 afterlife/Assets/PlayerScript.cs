using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    CharacterController cc;
    public float MovementSpeed = 10f;

    float ySpeed = 0;
    float Gravity = -15f;
    public Transform fpCamera;
    float pitch = 0f;

    [Range(5, 15)]
    float mouseSen = 10f;
    [Range(45, 85)]
    float pitchRange = 45f;

    float xInput = 0f;
    float zInput = 0f;
    float xMouse = 0f;
    float yMouse = 0f;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
        Vector3 move = new Vector3(xInput, 0, zInput);
        move = Vector3.ClampMagnitude(move, MovementSpeed);
        move = transform.TransformVector(move);

        if (cc.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = 10f;
            }
            else
            {
                ySpeed = Gravity * Time.deltaTime;
            }
        }
        else
        {
            ySpeed += Gravity * Time.deltaTime;
        }
        //cc.Move(new Vector3(xInput, ySpeed, zInput)* Time.deltaTime);
        cc.Move((move + new Vector3(0, ySpeed, 0)) * Time.deltaTime);

        transform.Rotate(0, xMouse, 0);
        pitch -= yMouse;
        pitch = Mathf.Clamp(pitch, -pitchRange, pitchRange);
        Quaternion camRotation = Quaternion.Euler(pitch,0,0);
        fpCamera.localRotation = camRotation;
    }

    void GetInputs()
    {
        xInput = Input.GetAxis("Horizontal") * MovementSpeed;
        zInput = Input.GetAxis("Vertical") * MovementSpeed;
        xMouse = Input.GetAxis("Mouse X") * mouseSen;
        yMouse = Input.GetAxis("Mouse Y") * mouseSen;
    }
}
