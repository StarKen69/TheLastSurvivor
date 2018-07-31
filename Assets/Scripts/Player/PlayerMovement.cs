using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float walkSpeed = 5, runSpeed = 8;
    public float rotateSpeed = 5;
    public float jumpForce = 1;

    public PlayerBase playerBase;
    public new Rigidbody rigidbody;

    private float lastMoveX, lastMoveZ;

    public void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * Time.deltaTime;

        float rotY = Input.GetAxis("Mouse X") * rotateSpeed;

        if(playerBase.IsGrounded())
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveX *= runSpeed;
                moveZ *= runSpeed;
            }
            else
            {
                moveX *= walkSpeed;
                moveZ *= walkSpeed;
            }
        } else
        {
            moveX = lastMoveX;
            moveZ = lastMoveZ;
        }

        transform.Translate(moveX, 0, moveZ);
        transform.Rotate(0, rotY, 0);

        lastMoveX = moveX;
        lastMoveZ = moveZ;

        if (Input.GetKey(KeyCode.Space) && playerBase.IsGrounded())
        {
            rigidbody.AddRelativeForce(transform.up * Time.deltaTime * jumpForce * 120, ForceMode.VelocityChange);
        }
    }
}
