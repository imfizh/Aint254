using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_look : MonoBehaviour
{
    public static bool curserLocked = true;
    public Transform player;
    public Transform cam;

    public float xSens = 150.0f;
    public float ySens = 150.0f;
    float maxAngle = 60.0f;
    private Quaternion camCentre;
    // Start is called before the first frame update
    void Start()
    {
        camCentre = cam.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        SetY();
        SetX();
        updateCurserLocked();
    }
    void SetY()
    {
        float t_Input = Input.GetAxis("Mouse Y") * ySens * Time.deltaTime;
        Quaternion t_ang = Quaternion.AngleAxis(t_Input, -Vector3.right); //rotates on left axis (makes it go up and down)
        Quaternion t_delta = cam.localRotation * t_ang;
        if (Quaternion.Angle(camCentre, t_delta) < maxAngle)
        {
            cam.localRotation = t_delta;
        }
    }
    void SetX()
    {
        float t_Input = Input.GetAxis("Mouse X") * xSens * Time.deltaTime;
        Quaternion t_ang = Quaternion.AngleAxis(t_Input, Vector3.up); //rotates on up axis (spins around it)
        Quaternion t_delta = player.localRotation * t_ang;
        player.localRotation = t_delta;
    }
    void updateCurserLocked()
    {
        if (curserLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                curserLocked = false;
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                curserLocked = true;
            }
        }
    }
}
