using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerbody;
    public Animator animator;
    public CameraFollow cameraFollow;
    int mouseSpeed = 100;
    public int playerSpeed = 5;

    float horizontal;
    float vertical;

    float xRotation;
    float yRotation;

    bool isMovingForward;
    int forwardSpeed = 5;
    int backwardSpeed = 3;
    bool isMovingBackward;

    // Start is called before the first frame update
    void Start()
    {
        playerbody = GetComponent<Rigidbody>();
        animator = GameObject.Find("Player").transform.Find("Michelle").GetComponent<Animator>();
        cameraFollow = FindObjectOfType<CameraFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        var mouseLeftRight = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        var mouseUpDown = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;

        yRotation += mouseLeftRight;

        //cameraFollow.transform.rotation = Quaternion.Euler(0, yRotation, 0);
        playerbody.transform.rotation = Quaternion.Euler(0, yRotation, 0);
        MovePlayer();
        PlayAnimation();
    }

    public void MovePlayer()
    {
        if (isMovingForward)
        {
            playerSpeed = forwardSpeed;
        }

        else
        {
            playerSpeed = backwardSpeed;
        }

        transform.localPosition += (transform.right * horizontal + transform.forward * vertical) * playerSpeed * Time.deltaTime;

    }

    public void PlayAnimation()
    {
        if (Input.GetKey(KeyCode.W))
        {
            print("W is pressed");
            animator.SetBool("MoveForward", true);
            isMovingForward = true;
        }

        else if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("MoveForward", false);
            isMovingForward = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            print("W is pressed");
            animator.SetBool("MoveBackward", true);
        }

        else if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("MoveBackward", false);
        }
    }

}
