using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class P_Control : MonoBehaviour {

    // Use this for initialization
    public float speed, hor, ver;
    private Vector3 movement = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector2 stickInput, rStickInput;
    public float deadzone;
    public Camera camera;
    CharacterController controller;
    void Start()
    {
        controller = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        if(!XRSettings.enabled)
        {
            HandleLook();
        }
        else
        {
            HandleVRLook();
        }
        
    }

    private void HandleMovement()
    {
        stickInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (stickInput.magnitude < deadzone)
        {
            stickInput = Vector2.zero;
        }
        else
        {
            stickInput = stickInput.normalized * ((stickInput.magnitude - deadzone) / (1 - deadzone));
        }

        movement = new Vector3(stickInput.x, 0, stickInput.y);//do his

        controller.Move(this.transform.TransformDirection(movement) * Time.deltaTime * speed);
    }

    private void HandleLook()
    {
        rStickInput = new Vector2(Input.GetAxis("RightStickX"), Input.GetAxis("RightStickY"));
        if (rStickInput.magnitude < deadzone)
        {
            rStickInput = Vector2.zero;
        }
        else
        {
            rStickInput = rStickInput.normalized * ((rStickInput.magnitude - deadzone) / (1 - deadzone));
        }
        rotation = new Vector3(rStickInput.x, rStickInput.y, 0);
        camera.transform.eulerAngles += new Vector3(rotation.y,0, 0)  * 5f;
        this.transform.eulerAngles += new Vector3(0, rotation.x, 0) * 5f;
    }

    private void HandleVRLook()
    {
        camera.transform.eulerAngles = new Vector3(InputTracking.GetLocalPosition(XRNode.CenterEye).x, 0, 0);
        this.transform.eulerAngles = new Vector3(0, InputTracking.GetLocalRotation(XRNode.CenterEye).y, 0);
    }
}
