using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerbody;
    public Animator animator;
    public CameraFollow cameraFollow;
    public ChangeCubeColor changeCubeColor;
    int mouseSpeed = 100;
    public int playerSpeed = 30;

    float horizontal;
    float vertical;

    float xRotation;
    float yRotation;

    bool isMovingForward;
    int forwardSpeed = 20;
    int backwardSpeed = 3;
    bool isMovingBackward;
    Quaternion newRotation;
    float MoveX, MoveY, MoveZ;

    // Start is called before the first frame update
    void Start()
    {
        playerbody = GetComponent<Rigidbody>();
        animator = GameObject.Find("Player").transform.Find("Michelle").GetComponent<Animator>();
        cameraFollow = FindObjectOfType<CameraFollow>();
        changeCubeColor = FindObjectOfType<ChangeCubeColor>();
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

        if(isMovingForward == false)
            animator.SetBool("MoveForward", false);

        if (isMovingForward == true)
            animator.SetBool("MoveForward", true);


    }

    public void MovePlayer()
    {
        

    }

    public void PlayAnimation()
    {
        MoveX = 0; 
        MoveY = 0; 
        MoveZ = 0;
        if (Input.GetKey(KeyCode.W))
        {
            //playerbody.AddForce( 0, 0, playerSpeed) ;
            MoveZ = +1;
            playerbody.transform.rotation = Quaternion.Euler(0, 0, 0);
            newRotation = playerbody.transform.rotation;

            isMovingForward = true;
        }
        else if(Input.GetKeyUp(KeyCode.W))
        {
            forwardSpeed = 20;
            playerbody.transform.rotation = newRotation;
            isMovingForward = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            //playerbody.AddForce(0, 0, -playerSpeed);
            MoveZ = -1;
            playerbody.transform.rotation = Quaternion.Euler(0, 180, 0);
            newRotation = playerbody.transform.rotation;
            isMovingForward = true;
        }

        else if (Input.GetKeyUp(KeyCode.S))
        {
            forwardSpeed = 20;
            playerbody.transform.rotation = newRotation;
            isMovingForward = false;
        }


        if (Input.GetKey(KeyCode.D))
        {
            //playerbody.AddForce(playerSpeed, 0, 0);
            MoveX = +1;
            playerbody.transform.rotation = Quaternion.Euler(0, 90, 0);
            newRotation = playerbody.transform.rotation;
            isMovingForward = true;
        }

        else if (Input.GetKeyUp(KeyCode.D))
        {
            forwardSpeed = 20;
            playerbody.transform.rotation = newRotation;
            isMovingForward = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            //playerbody.AddForce(-playerSpeed, 0, 0);
            MoveX = -1;
            playerbody.transform.rotation = Quaternion.Euler(0, -90, 0);
            newRotation = playerbody.transform.rotation;
            isMovingForward = true;
        }

        else if (Input.GetKeyUp(KeyCode.A))
        {
            forwardSpeed = 20;
            playerbody.transform.rotation = newRotation;
            isMovingForward = false;
        }


        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            forwardSpeed = 10;
            playerbody.transform.rotation = Quaternion.Euler(0, -110, 0);
            newRotation = playerbody.transform.rotation;
            isMovingForward = true;
        }

        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            forwardSpeed = 20;
            playerbody.transform.rotation = newRotation;
            isMovingForward = false;
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            forwardSpeed = 10;
            playerbody.transform.rotation = Quaternion.Euler(0, 130, 0);
            newRotation = playerbody.transform.rotation;
            isMovingForward = true;
        }

        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            forwardSpeed = 20;
            playerbody.transform.rotation = newRotation;
            isMovingForward = false;
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            forwardSpeed = 10;
            playerbody.transform.rotation = Quaternion.Euler(0, 30, 0);
            newRotation = playerbody.transform.rotation;
            isMovingForward = true;
        }

        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            forwardSpeed = 20;
            playerbody.transform.rotation = newRotation;
            isMovingForward = false;
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            forwardSpeed = 20;
            playerbody.transform.rotation = Quaternion.Euler(0, -30, 0);
            newRotation = playerbody.transform.rotation;
            isMovingForward = true;

        }

        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            forwardSpeed = 20;
            playerbody.transform.rotation = newRotation;
            isMovingForward = false;
        }

        playerbody.transform.rotation = newRotation;

        Vector3 moveDir = new Vector3(MoveX, MoveY, MoveZ).normalized;
        transform.position += moveDir * playerSpeed * Time.deltaTime;

    }

    public IEnumerator startColorchange()
    {
        changeCubeColor.successfailureText.text = "Great JOB!!!!!!!!!";
        yield return new WaitForSeconds(1f);
        changeCubeColor.successfailureText.text = "";

        yield return new WaitForSeconds(1f);
        changeCubeColor.setCubeColor();
    }
    public IEnumerator tryAgain()
    {
        changeCubeColor.successfailureText.text = "TRY AGAIN!!!!!!!";
        yield return new WaitForSeconds(0.5f);
        changeCubeColor.successfailureText.text = "";
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag!= "ground")
        {
            if (collision.gameObject.GetComponent<Renderer>().material.name.Contains(changeCubeColor.colorToFind))
            {
                print("You hit " + collision.gameObject.GetComponent<Renderer>().material.name);
                StartCoroutine(startColorchange());
            }

            else
            {
                StartCoroutine(tryAgain());
            }
            
        }
    }
}
