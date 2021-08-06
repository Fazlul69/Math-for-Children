using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed = 10.0f;

    private int desiredLane = 1; //0: left, 1:middle, 2:right
    public float laneDistance = 4; // the distance between two lane
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = forwardSpeed;

        //gather the input where lane we should be
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if(desiredLane == 3)
                desiredLane = 2;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if(desiredLane == -1)
                desiredLane = 0;
        }
        //calculate where we should be in the future
         Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

         if(desiredLane == 0)
         {
             targetPosition += Vector3.left * laneDistance;
         }
         else if(desiredLane == 2)
         {
             targetPosition += Vector3.right * laneDistance;
         }

         transform.position = Vector3.Lerp(transform.position, targetPosition, 80* Time.deltaTime);

    }

    private void FixedUpdate()
    {
        controller.Move(direction*Time.deltaTime);
    }
}
