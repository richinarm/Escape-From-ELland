using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody playerbody;
    int mouseSpeed = 100;
    int playerSpeed = 5;

    float horizontal;
    float vertical;

    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        playerbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        var mouseLeftRight = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        var mouseUpDown = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;

        yRotation += mouseLeftRight;

        playerbody.transform.rotation = Quaternion.Euler(0, yRotation, 0);
        MovePlayer();
    }

    public void MovePlayer()
    {
        transform.localPosition += (transform.right * horizontal + transform.forward * vertical) * playerSpeed * Time.deltaTime; 
    }
}
