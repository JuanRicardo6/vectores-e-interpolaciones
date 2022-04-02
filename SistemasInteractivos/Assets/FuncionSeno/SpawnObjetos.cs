using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjetos : MonoBehaviour
{
    static SpawnObjetos instance;
    public static SpawnObjetos Instance {
        get => instance;
    }

    [SerializeField] GameObject objeto;
    [SerializeField] Vector3 posicionF;
    [SerializeField] int cantidadObjetos;
    [Range(1, 100)]
    public float amplitud;
    [Range(-100, 100)]
    [SerializeField] float desplazamiento;

    public bool cambio;
    Vector3 positition;

    void Start()
    {
        instance = this;
        desplazamiento = -20;
        
        float c = posicionF.magnitude / cantidadObjetos;
        Vector3 pos = new Vector3();
        for (int i = 0; i < cantidadObjetos; i++)
        {
            pos.x = (transform.position.x + (c * i));
            var newchild = Instantiate(objeto, transform);
            newchild.transform.localPosition = pos;
        }
        amplitud = 1;
    }
    private void Update()
    {
        positition.x = desplazamiento;
        transform.localPosition = positition;
    }

}
