using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PhysicMover : MonoBehaviour
{
    [SerializeField]
    private Vector3 acceleration;
    private Vector3 velocity;

    [SerializeField] bool tocandoAgua,tocandoAire;
    [SerializeField] [Range(0, 1)]
    private float dampFactor, coeficienteDeFriccion, coAg, coAi;
    [SerializeField] private float mass,gravedad;
    [SerializeField] private Vector3 fuerza;

    float areaFrontal;
    private void Start()
    {
        areaFrontal = transform.localScale.x;
    }
    private void Update()
    {
        
        Move();
        CheckLimits();
        
    }

    public void Move()
    {
        acceleration = Vector3.zero;
        //ApplyForce(fuerza);
        //ApplyForce(Friccion(fuerza));
        ApplyForce(new Vector3(0, gravedad*mass, 0));
        ApplyForce(ResistenciaFluido(new Vector3(0, gravedad*mass, 0),tocandoAgua));
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        
    }

    private void CheckLimits()
    {
        Vector3 position = transform.position;
        if ((position.x > 4.5f || position.x < -4.5f))
        {
            if (position.x > 4.5f) transform.position = new Vector3(4.5f, transform.position.y);
            if (position.x < -4.5f) transform.position = new Vector3(-4.5f, transform.position.y);

            velocity.x = velocity.x * -1;
            velocity *= dampFactor;
        }

        else if (position.y > 4.5f || position.y < -4.5f)
        {

            if (position.y > 4.5f) transform.position = new Vector3(transform.position.x, 4.5f);
            if (position.y < -4.5f) transform.position = new Vector3(transform.position.x, -4.5f);
            velocity.y = velocity.y * -1;
            velocity *= dampFactor;
        }
    }

    private void ApplyForce(Vector3 force)
    {
        acceleration += force / mass;
    }
    private Vector3 Friccion(Vector3 force)
    {
        return -velocity.normalized * coeficienteDeFriccion*force.magnitude;
    }
    private Vector3 ResistenciaFluido(Vector3 force,bool tocandoAgua)
    {
        if (tocandoAgua == true)
        {
            Debug.Log("entro");
            return -velocity.normalized * coAg *velocity.magnitude*velocity.magnitude*0.5f*areaFrontal;
        }
        else if(tocandoAire==true)
        {
            return -velocity.normalized * coAi * velocity.magnitude * velocity.magnitude * 0.5f * areaFrontal;//-velocity.normalized * coeficienteDeFriccion * force.magnitude;
        }
        else
        {
            return Vector3.zero;
        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Agua"))
        {
            tocandoAgua = true;
        }
        if (other.CompareTag("Aire"))
        {
            tocandoAire = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Agua"))
        {
            tocandoAgua = false;
        }

    }

    //private void CheckLimits()
    //{
    //    // 
    //    var pos = transform.position;

    //    if (Mathf.Abs(pos.x) > limits.x)
    //    {
    //        pos = (Vector3)new Vector2(limits.x * Mathf.Sign(pos.x), pos.y);
    //        transform.position = pos;
    //        velocity = (Vector3)new Vector2(Mathf.Abs(velocity.x)*-Mathf.Sign(velocity.x),velocity.y)*dampFactor;
    //    }
    //    if (Mathf.Abs(pos.y) > limits.y)
    //    {
    //        pos = (Vector3)new Vector2(pos.x, limits.y*Mathf.Sign(pos.y));
    //        transform.position = pos;
    //        velocity = (Vector3)new Vector2(velocity.x, Mathf.Abs(velocity.y) * -Mathf.Sign(velocity.y))*dampFactor;
    //    }
    //}
}
