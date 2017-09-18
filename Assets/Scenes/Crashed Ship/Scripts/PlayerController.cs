using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    private float speed;
    public float normalSpeed = 20.0f;
    public float sprint = 15.0f;
    public float jumpSpeed = 200f;
    private float gravity;
    private Vector3 movement = Vector3.zero;
    CharacterController controller;
    public Camera cam;
    public float sensitivityX = 60.0f;
    public float sensitivityY = 60.0f;
    public float maximumX = 360f;
    public float minimumX = -360f;
    public float maximumY = 60f;
    public float minimumY = -60f;
    float rotationY = 20f;
    private float groundedGravity = 250.0f;
    private float jumpGravity = 9.89f;
    private RaycastHit hit;
    private float dist = 1.2f;
    private Vector3 dir = Vector3.down;
    public bool lockCursor;
    
    
    
    
    // Use this for initialization
    void Start()
    {

        controller = GetComponent<CharacterController>();// Gets the playercontroller component


    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.DrawRay(transform.position, dir * dist, Color.green);//Displays a line where the ray is casting for debug purposes
        
        if (Physics.Raycast(transform.position, dir, out hit, dist))//Raycasting to check if the player is grounded
        {
            //Debug.Log("Grounded");

            
            movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Jump"), Input.GetAxis("Vertical"));//Gets Inputs from the Input manager in a vector3 variable
            movement = transform.TransformDirection(movement);//Transforms the player controller the direction the camera is looking
            movement *= speed;//Multiplies the movement by a value for walking and jumping
            gravity = groundedGravity;//Increases the gravity while being grounded

            speed = normalSpeed;

            

            
        }
        else
        {
            
            gravity = jumpGravity;
        }
        if (Input.GetAxis("Jump") == 1)
        {
            speed = jumpSpeed;
            
        }
        if (Input.GetKey("left shift") == true)
        {
            speed = sprint;
            
            
        }
        
        
        

        movement.y -= gravity * Time.deltaTime;
        controller.Move(movement * Time.deltaTime);
                                                   
                                                   

        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;//Using EularAngles to in conjuction with Mouse X to calculate rotation

            rotationY += Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime;//Same thing with Mouse Y, EularAngles added at the bottom for reasons
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);//Clamps Mouse Y so you can't look too far up or down

            transform.localEulerAngles = new Vector3(0, rotationX, 0);//Rotates the player controller on the X axis
            cam.transform.localEulerAngles = new Vector3(-rotationY, 0, 0);//Rotates the camera on the Y axis. This is so that when you look up and press W, you don't move up.


        }
        else if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime, 0);
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;

        }
        

        

        

       












    }

   
    


}
    
    




            

            

        

    






