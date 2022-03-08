using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteoVectores : MonoBehaviour
{
    public Vectores vector1, vector2, vectorR, puntoInicio, vectorNormalizado,vectorInterpolado;
    public float magnitud;
    public ColorVectores color;
    [Range(0,1)]
    public float rango;

    void Update()
    {
        vectorR = (vector2 - vector1) * rango;
        vectorInterpolado = vector1.Lerp(vector2, rango);
        puntoInicio = vector1;
        magnitud = vectorR.Magnitud();
        vectorNormalizado = vectorR.Normalizar();
        vector1.Draw(color.colores[0]);
        vector2.Draw(color.colores[1]);
        vectorR.Draw(color.colores[2]);
        vectorInterpolado.Draw(color.colores[3]);
        vectorR.Draw(puntoInicio, color.colores[2]);
        
    }
}
