using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    #region Variables publicas
    public bool canMove = true;
    public float walkSpeed = 5, runSpeed = 8;
    public float rotateSpeed = 5;
    public float jumpForce = 5;
    public Animator animator;
    #endregion

    #region Variables privadas
    private float lastMoveX, lastMoveZ;
    private PlayerBase playerBase;
    private new Rigidbody rigidbody;
    private bool recentlyJumped;
    #endregion

    public void Start()
    {
        playerBase = GetComponent<PlayerBase>();
        rigidbody = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        if(canMove)
        {
            float moveX = Input.GetAxis("Horizontal") * Time.deltaTime;
            float moveZ = Input.GetAxis("Vertical") * Time.deltaTime;

            float rotY = Input.GetAxis("Mouse X") * rotateSpeed;
            float rotX = -Input.GetAxis("Mouse Y") * rotateSpeed;

            if (moveX == 0 && moveZ == 0)
            {
                ExecuteAnimation("Idle");
            }
            else
            {
                if (playerBase.IsGrounded())
                {
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        moveX *= runSpeed;
                        moveZ *= runSpeed;

                        ExecuteAnimation("Run");
                        animator.SetFloat("MoveSpeed", 2);
                    }
                    else
                    {
                        moveX *= walkSpeed;
                        moveZ *= walkSpeed;

                        ExecuteAnimation("Walk");
                        animator.SetFloat("MoveSpeed", 1);
                    }

                    if (Input.GetKey(KeyCode.Space) && !recentlyJumped) Jump();
                }
            }

            if (!playerBase.IsGrounded())
            {
                moveX = lastMoveX;
                moveZ = lastMoveZ;
            }

            transform.Translate(moveX, 0, moveZ);

            lastMoveX = moveX;
            lastMoveZ = moveZ;
        }
    }

    public void Jump()
    {
        recentlyJumped = true;
        rigidbody.AddRelativeForce(transform.up * jumpForce, ForceMode.VelocityChange);
        Invoke("ResetRecentlyJumped", 0.5f);
    }

    private void ResetRecentlyJumped() { recentlyJumped = false; }

    private void ExecuteAnimation(string animName)
    {
        if(animName != "Idle")
        {
            animator.SetBool("IsMoving", true);
        } else
        {
            animator.SetBool("IsMoving", false);
        }
    }
}
