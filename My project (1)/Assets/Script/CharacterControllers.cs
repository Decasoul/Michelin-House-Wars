using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllers : MonoBehaviour
{
    [SerializeField] private Rigidbody characterBody;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float lookSensitivityH = 2f;
    [SerializeField] private float lookSensitivityV = 2f;
    [SerializeField] private Camera cam;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private float pitchClampUp = -25;
    private float pitchClampDown = 15;

    private void Start()
    
    {
        characterBody = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }
    void Update()
    {
        MouseRotation();
        {
            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                characterBody.velocity = new Vector3(characterBody.velocity.x, jumpForce, characterBody.velocity.z);
            }

            float leftRight = Input.GetAxisRaw("Horizontal");
            float forwardBack = Input.GetAxisRaw("Vertical");

            Vector3 CharacterController = new Vector3(leftRight, 0, forwardBack).normalized;
            characterBody.transform.Translate(moveSpeed * Time.deltaTime * CharacterController);
        }
    }
    public bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, whatIsGround);
    }
    private void MouseRotation()
    {
        yaw += lookSensitivityH * Input.GetAxis("Mouse X");
        pitch -= lookSensitivityV * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, pitchClampUp, pitchClampDown);

        cam.transform.localEulerAngles = new Vector3(pitch, 0.0f, 0.0f);
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
    }
}

