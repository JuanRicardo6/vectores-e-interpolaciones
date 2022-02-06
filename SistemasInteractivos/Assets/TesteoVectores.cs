using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteoVectores : MonoBehaviour
{
    public Vectores vector1, vector2, vectorR, puntoInicio, vectorNormalizado,vectorInterpolado;
    public float magnitud;
    [Range(0,1)]
    public float rango;

    void Update()
    {
        vectorR = vectorR.MultVectores(vectorR.RestarVectores(vector1, vector2), rango);
        vectorInterpolado.x = vector2.x;
        vectorInterpolado.y = vector2.y;
        vectorInterpolado = vectorInterpolado.Lerp(vector1, rango);
        puntoInicio.x = vector2.x;
        puntoInicio.y = vector2.y;
        
        magnitud = vectorR.Magnitud();
        vectorNormalizado = vectorR.Normalizar();

        vector1.Draw();
        vector2.Draw();
        vectorR.Draw();
        vectorInterpolado.Draw();
        vectorR.Draw(puntoInicio);
        
    }
}
