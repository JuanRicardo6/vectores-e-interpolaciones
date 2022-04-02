using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacion : MonoBehaviour
{
    public Vector3 rot;
   
    void Update()
    {
        this.transform.Rotate(rot);
    }
}
