using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physicmove : MonoBehaviour
{
    [SerializeField]
    private Vector3 acceleration;
    private Vector3 velocity;
    [SerializeField] bool tocandoAgua, tocandoAire;
    [SerializeField]
    [Range(0, 1)]
    private float dampFactor;
    [SerializeField] private float mass, gravedad;
    [SerializeField] private Vector3 fuerza;
    [SerializeField]
    [Range(0, 100)]
    private float Coefriccion,coAg, coAi;
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
        ApplyForce(new Vector3(0,mass*gravedad,0));
        //ApplyForce(Fuerza_Friccion(fuerza));
        //Vector3 
        ApplyForce(ResistenciaFluido(new Vector3(0, gravedad * mass, 0), tocandoAgua));
        //ApplyForce(new Vector3(0, -9.8f, 0));
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;


    }

    private void CheckLimits()
    {
        Vector3 position = transform.position;
        if ((position.x > 4f || position.x < -4f))
        {
            if (position.x > 4f) transform.position = new Vector3(4f, transform.position.y);
            if (position.x < -4f) transform.position = new Vector3(-4f, transform.position.y);

            velocity.x = velocity.x * -1;
            velocity *= dampFactor;
        }

        else if (position.y > 4f || position.y < -4f)
        {

            if (position.y > 4f) transform.position = new Vector3(transform.position.x, 4f);
            if (position.y < -4f) transform.position = new Vector3(transform.position.x, -4f);
            velocity.y = velocity.y * -1;
            velocity *= dampFactor;
        }
    }

    private void ApplyForce(Vector3 force)
    {
        acceleration += force / mass;
    }

    private Vector3 Fuerza_Friccion (Vector3 force)
    {
        return -velocity.normalized* Coefriccion* force.magnitude;
    }

    private Vector3 ResistenciaFluido(Vector3 force, bool tocandoAgua)
    {
        if (tocandoAgua == true)
        {
            Debug.Log("entro");
            return -velocity.normalized * coAg * velocity.magnitude * velocity.magnitude * 0.5f * areaFrontal;
        }
        else if (tocandoAire == true)
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
        if (other.CompareTag("Aqua"))
        {
            tocandoAgua = true;
        }
        if (other.CompareTag("Air"))
        {
            tocandoAire = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Aqua"))
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
