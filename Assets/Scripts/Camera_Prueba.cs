using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Prueba : MonoBehaviour {

    public Animator anim;

    #region // variables publicas

    public Camera CPcamera;
    public float Caminar;
    public float Correr;
    public float Salto;

    float V;


    public enum RotationAxes { MouseXAnddY = 0, MouseX = 1, MouseY = 2 };
    public RotationAxes axes = RotationAxes.MouseXAnddY;
    public float sensitivityX = 15F;

    public float minimumX = -360F;
    public float maximumX = 360F;

    float rotationX = 0F;

    Quaternion originalRotation;

    #endregion

    #region // region start

    void Start () {
       
        anim.GetComponent<Animator>();

        {
            // Make the rigid body not change rotation
            if (GetComponent<Rigidbody>())
                GetComponent<Rigidbody>().freezeRotation = true;
            originalRotation = transform.localRotation;
        }

    }

    private void Caminarr()
    {
        anim.SetTrigger("Caminar");
    }

    #endregion

    #region // region de controles (W,S,A,D) (update)

    void Update () {

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, Time.deltaTime * Caminar);
        }
        else
        {
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(0, 0, -0.1f);
            }
            else
            {
                if (Input.GetKey(KeyCode.A))
                {
                    transform.Translate(-0.1f, 0, 0);
                }

                else
                {
                    if (Input.GetKey(KeyCode.D))
                    {
                        transform.Translate(0.1f, 0, 0);
                    }
                }

            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0, 0, Time.deltaTime * Correr);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(0, Time.deltaTime * Salto, 0);
        }


        #region //Salto (arreglar)
        //else
        //{

            
            //if (Input.GetKeyUp(KeyCode.Space))
            //{
            //transform.Translate(0, Time.deltaTime * Salto, 0);
            //}
            //}
            #endregion


            #endregion

            #region // region rotamiento de camara (Eje Y,Z)
            if (axes == RotationAxes.MouseXAnddY)
        {

        }
        else if (axes == RotationAxes.MouseX)
        {
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationX = ClampAngle(rotationX, minimumX, maximumX);

            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            transform.localRotation = originalRotation * xQuaternion;
        }
        else
        {


        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
    #endregion
}


