using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = new Vector3 (playerMovement.transform.position.x, playerMovement.transform.position.y + 10, playerMovement.transform.position.z -10);
        //transform.rotation = Quaternion.Euler(0, playerMovement.transform.rotation.y, 0);
    }
}
