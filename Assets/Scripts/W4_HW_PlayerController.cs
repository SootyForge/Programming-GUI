using System.Collections;
using UnityEngine;

[AddComponentMenu("CharacterController")]
[RequireComponent(typeof(CharacterController))]
public class W4_HW_PlayerController : MonoBehaviour
{
    #region Variables
    #region Player Movement
    [Header("MOVEMENT VARIABLES")]
    [Range(0f, 10f)]
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;
    public CharacterController controller;
    [Space(10)]
    #endregion Player Movement

    #region Camera Movement
    [Header("CAMERA VARIABLES")]
    [Header("Rotational Axis")]
    public RotationalAxis axis = RotationalAxis.MouseX;
    [Header("Sensitivity")]
    public float sensitivityX = 10.0f;
    public float sensitivityY = 10.0f;
    [Header("Y Rotation Clamp")]
    public float minimumY = -60.0f;
    public float maximumY = 60.0f;
    float rotationY = 0.0f;
    public new Camera camera;
    #endregion Camera Movement
    #endregion Variables

    // Use this for initialization
    private void Start ()
    {
        controller = this.GetComponent<CharacterController>();
        camera = this.GetComponentInChildren<Camera>();

        if (this.GetComponent<Rigidbody>())
        {
            this.GetComponent<Rigidbody>().freezeRotation = true;
        }
    }
	
	// Update is called once per frame
	private void Update ()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            moveDirection = transform.TransformDirection(moveDirection);

            moveDirection *= speed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime; // Prevents falling while paused
        controller.Move(moveDirection * Time.deltaTime);

        #region Mouse X and Y
        //if our axis is set to Mouse X and Y
        if (axis == RotationalAxis.MouseXandY)
        {
            //float rotation x is equal to our y axis plus the mouse input on the Mouse X times our x sensitivity
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
            //our rotation Y is pulse equals  our mouse input for Mouse Y times Y sensitivity
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            //the rotation Y is clamped using Mathf and we are clamping the y rotation to the Y min and Y max
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
            //transform our local position to the nex vector3 rotaion - y rotaion on the x axis and x rotation on the y axis
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        #endregion
        #region Mouse X
        //else if we are rotating on the X
        else if (axis == RotationalAxis.MouseX)
        {
            //transform the rotation on our game objects Y by our Mouse input Mouse X times X sensitivity
            //x                y                          z
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }
        #endregion
        #region Mouse Y
        //else we are only rotation on the Y
        else
        {
            //our rotation Y is pulse equals  our mouse input for Mouse Y times Y sensitivity
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            //the rotation Y is clamped using Mathf and we are clamping the y rotation to the Y min and Y max
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
            //transform our local position to the nex vector3 rotaion - y rotaion on the x axis and local euler angle Y on the y axis
            transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
        }
        #endregion
    }
}
