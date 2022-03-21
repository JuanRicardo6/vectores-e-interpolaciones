using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorPolar : MonoBehaviour
{
    [SerializeField] float radio, radialSpeed, tetha, angularSpeed;
    [SerializeField] bool limiteAlcanzadoP, limiteAlacanzadoN;
    void Update()
    {

        if (radio >= 0 && radio < 5)
        {
            if (limiteAlcanzadoP == false)
            {
                radio += radialSpeed * Time.deltaTime;
            }
            else
            {
                limiteAlacanzadoN = false;
                radio -= radialSpeed * Time.deltaTime;
            }
        }
        else if (radio > 5)
        {
            limiteAlcanzadoP = true;
            radio -= radialSpeed * Time.deltaTime;
        }
        else if (radio < 0 && radio > -5)
        {
            if (limiteAlacanzadoN == false)
            {
                radio -= radialSpeed * Time.deltaTime;
            }
            else
            {
                limiteAlcanzadoP = false;
                radio += radialSpeed * Time.deltaTime;
            }
        }
        else if (radio < -5)
        {
            limiteAlacanzadoN = true;
            radio += radialSpeed * Time.deltaTime;
        }

        tetha += angularSpeed * Time.deltaTime;

        Vector3 cartesian = PolarToCartesian(radio, tetha);
        Vector3 tangent = new Vector3(-Mathf.Sin(tetha),Mathf.Cos(tetha)); // velocidad
        transform.position = cartesian;
        Debug.DrawLine(Vector3.zero, cartesian);
        float angle = Mathf.Atan2(tangent.y, tangent.x);
        transform.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg);
    }
    Vector3 PolarToCartesian(float radio, float tetha)
    {
        return new Vector3(radio * Mathf.Cos(tetha), radio * Mathf.Sin(tetha));
    }
}
