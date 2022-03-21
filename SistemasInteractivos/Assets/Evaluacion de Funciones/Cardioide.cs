using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cardioide : MonoBehaviour
{
    [SerializeField] float radio, tetha, angularSpeed,a;
    [SerializeField] Vector3 cartesian;
    
    void Update()
    {

        tetha += angularSpeed * Time.deltaTime;
        radio = a + a * Mathf.Sin(-tetha);

        cartesian = PolarToCartesian(radio, tetha);
        transform.position = cartesian;
        Debug.DrawLine(Vector3.zero, cartesian);
    }
    Vector3 PolarToCartesian(float radio, float tetha)
    {
        return new Vector3(radio * Mathf.Cos(tetha),0, radio * Mathf.Sin(tetha));
    }
}
