using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seno : MonoBehaviour
{
   
    [SerializeField] Vector3 posicionNueva;
    float operacion;
    
    void Start()
    {
        posicionNueva = transform.position;
    }
    
    void Update()
    {
        if (SpawnObjetos.Instance.cambio == true)
        {
            operacion = transform.position.x * Time.time;
        }
        else
        {
            operacion = transform.position.x + Time.time;
        }
        posicionNueva.y = (Mathf.Sin(operacion) * SpawnObjetos.Instance.amplitud); 
        transform.localPosition = posicionNueva;
    }
}
