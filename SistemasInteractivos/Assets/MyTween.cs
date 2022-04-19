using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTween : MonoBehaviour
{
    [SerializeField] AnimationCurve curva;
    [SerializeField] float duration;
    [SerializeField] Vector3 startPos, endPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time / duration;
        transform.position = Vector3.LerpUnclamped(startPos, endPos, curva.Evaluate(t));
        
    }
    float easeOutQuint(float x)
    {
        return 1f - Mathf.Pow(1f-x,5);
    }
   
}
