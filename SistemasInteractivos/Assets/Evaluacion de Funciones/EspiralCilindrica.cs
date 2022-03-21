using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspiralCilindrica : MonoBehaviour
{
    [SerializeField] float radio, tetha, angularSpeed,altura, velocidadAltura, posicionFinal,posicionInicial;
    [SerializeField] TrailRenderer trail;
    [SerializeField] Vector3 cartesian;
    private void Awake()
    {
        posicionInicial = altura;
    }
    void Update()
    {
        altura+=velocidadAltura*Time.deltaTime;
        tetha += angularSpeed * Time.deltaTime;

        if (altura <= posicionFinal)
        {

            StartCoroutine("ReducirTrail");
        }
        

        cartesian = PolarToCartesian(radio, tetha,altura);
        transform.position = cartesian;
        Debug.DrawLine(Vector3.zero, cartesian);
    }
    Vector3 PolarToCartesian(float radio, float tetha,float altura)
    {
        return new Vector3(radio * Mathf.Cos(tetha),altura, radio * Mathf.Sin(tetha));
    }
    IEnumerator ReducirTrail()
    {
        trail.time = 0;
        //yield return new WaitForSeconds(0.5f);
        altura = posicionInicial;
        yield return new WaitForSeconds(0.2f);
        trail.time = 10;
    }
}
