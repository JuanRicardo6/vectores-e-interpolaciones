using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] Vector3 aceleration;
    [SerializeField] Vector3 velocity;
    [SerializeField] Vector3 position;
    [SerializeField] bool limitarVelocidad;
    [SerializeField] float limiteVelocidad;
    [Range(0, 1)]
    [SerializeField] float dumping;
    [SerializeField] bool changeAceleration;
    [SerializeField] float limite;
    [SerializeField] float radioObjeto;
    [SerializeField] bool centroG;
    [SerializeField] Transform centroGravitacional;
    [Range(1, 100)]
    [SerializeField] float fuerzaGravitatoria;
    [SerializeField] float gravedad;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Draw();
    }
    public void Move()
    {
        //aceleration = -(this.transform.position - centroGravitacional)*fuerzaGravitatoria;
        aceleration = CentroGravedad(centroG, aceleration, centroGravitacional, gravedad);
        float c = limite - radioObjeto;
        if (position.x >= c)
        {
            position.x = 4.5f;
            transform.position = position;
            aceleration.x = CambiarAcelearcion(aceleration.x, changeAceleration);
            velocity.x = ReducirVelocidad(velocity.x, dumping);
        }
        else if (position.x <= -c)
        {
            position.x = -4.5f;
            transform.position = position;
            aceleration.x = CambiarAcelearcion(aceleration.x, changeAceleration);
            velocity.x = ReducirVelocidad(velocity.x, dumping);
        }
        else if (transform.position.y >= c)
        {
            position.y = 4.5f;
            transform.position = position;
            aceleration.y = CambiarAcelearcion(aceleration.y, changeAceleration);
            velocity.y = ReducirVelocidad(velocity.y, dumping);
        }
        else if (transform.position.y <= -c)
        {
            position.y = -4.5f;
            transform.position = position;
            aceleration.y = CambiarAcelearcion(aceleration.y, changeAceleration);
            velocity.y = ReducirVelocidad(velocity.y, dumping);
        }

        velocity += aceleration * Time.deltaTime;
        velocity = LimitarVelocidad(limitarVelocidad, velocity, limiteVelocidad);
        position += velocity * Time.deltaTime;
        transform.position = position;
    }
    private void Draw()
    {
        Debug.DrawLine(transform.position, velocity + transform.position, Color.red);
        Debug.DrawLine(transform.position, aceleration + transform.position, Color.blue);
        Debug.DrawLine(transform.position, position, Color.green);
    }
    private float CambiarAcelearcion(float componente, bool aceleracionCambiante)
    {
        if (aceleracionCambiante == true)
        {
            componente = componente * -1;
            return componente;
        }
        else
        {
            return componente;
        }
    }
    private float ReducirVelocidad(float componente, float dumping)
    {
        componente = -(componente - componente * dumping);
        return componente;
    }
    Vector3 CentroGravedad(bool centroG, Vector3 aceleration, Transform centro, float gravedad)
    {
        if (centroG == true)
        {
            aceleration = (centro.position - this.transform.position);
            aceleration = aceleration.normalized * gravedad * fuerzaGravitatoria;
            return aceleration;
        }
        else
        {
            return aceleration;
        }
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

