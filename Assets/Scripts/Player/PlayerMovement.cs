using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    #region Variables publicas
    public float walkSpeed = 5, runSpeed = 8;
    public float rotateSpeed = 5;
    public float Salto;
    public float Tiempo;
    public static bool tocado = true;
    public Animator anim;


    public PlayerBase playerBase;
    public new Rigidbody rigidbody;

    #endregion

    #region Variables privadas
    private float lastMoveX, lastMoveZ;


    #endregion

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        #region Salto
        if (tocado == true && Input.GetKeyDown(KeyCode.Space) && playerBase.IsGrounded())
        {
            tocado = false;
            Invoke("Salta", 0f);
        }
        #endregion




    }

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


    }

    #region Salto
    public void Salta()
    {
        rigidbody.AddRelativeForce(transform.up * Time.deltaTime * Salto * 120, ForceMode.VelocityChange);
        Invoke("desbloc", Tiempo);
    }
    public void desbloc()
    {
        tocado = true;

    }
    #endregion

    


}
