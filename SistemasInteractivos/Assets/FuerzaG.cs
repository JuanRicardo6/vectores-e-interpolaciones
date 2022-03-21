using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuerzaG : MonoBehaviour
{

    [SerializeField]
    private Vector3 acceleration;
    [SerializeField]
    private Vector3 velocity;

    [SerializeField] Vector3 r;
    [SerializeField] bool quieto;

    [SerializeField] GameObject masaAjena;
    [SerializeField] float masaA;
    [SerializeField] bool limitarVelocidad;
    [SerializeField] float limiteVelocidad;

    public float mass;


    float areaFrontal;



    void Awake()
    {
        masaA = masaAjena.GetComponent<FuerzaG>().mass;

    }
    void Update()
    {
        Move(quieto);

    }
    public void Move(bool quieto)
    {
        if (quieto == true)
        {
            return;
        }
        r = masaAjena.transform.position - this.transform.position;
        acceleration = Vector3.zero;

        ApplyForce(FuerzaGrav(masaA, r));

        velocity += acceleration * Time.deltaTime;
        velocity = LimitarVelocidad(limitarVelocidad, velocity, limiteVelocidad);
        transform.position += velocity * Time.deltaTime;
    }
    private void ApplyForce(Vector3 force)
    {
        acceleration += force / mass;
    }
    private Vector3 FuerzaGrav(float masaA, Vector3 r)
    {
        Vector3 fg = new Vector3();
        fg = r.normalized * (mass * masaA) / (r.magnitude * r.magnitude);
        return fg;
    }
    private Vector3 LimitarVelocidad(bool limitar, Vector3 velocidad, float limite)
    {

        if (limitar == true && velocidad.magnitude > limite)
        {
            velocidad = velocidad.normalized * limite;
            return velocidad;
        }
        else
        {
            return velocidad;
        }
    }
}
