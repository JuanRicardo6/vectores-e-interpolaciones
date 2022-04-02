using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinMove : MonoBehaviour
{
    [SerializeField] Vector3 pos;
    [Range(0,5)]
    [SerializeField] float despX=1,despY=1;
    [SerializeField] float vel;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        pos.y = Mathf.Sin(Time.time*vel) * despY;
        pos.x = Mathf.Sin(Time.time*vel) * despX;
        
        transform.position = pos;
    }
}
