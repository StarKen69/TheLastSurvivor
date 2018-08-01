using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saltar : MonoBehaviour
{
    public float Tiempo;
    public float Salto;
    public static bool tocado = true;

    void Update()
    {

        if (tocado == true && Input.GetKeyDown(KeyCode.Space))
        {
            tocado = false;
            Invoke("Salta", 0f);
        }
    }
    public void Salta()
    {

        transform.Translate(0, Time.deltaTime * Salto, 0);
        Invoke("desbloc", Tiempo);
    }
    public void desbloc()
    {
        tocado = true;

    }
}
