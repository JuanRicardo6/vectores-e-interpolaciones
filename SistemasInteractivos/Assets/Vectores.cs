using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct Vectores 
{
    public float x, y;

    public Vectores(float v1, float v2) : this()
    {
        this.x = v1;
        this.y = v2;
    }

    public Vectores SumarVectores(Vectores vector)
    {
        return this+vector;
    }
    public Vectores RestarVectores(Vectores vector)
    {
        return this-vector;
    }
    public Vectores MultVectores(float escalar)
    {
        return this*escalar;
    }
    public void Draw()
    {
        Vector2 vectorInicial = new Vector2(0, 0);
        Vector2 vectorFinal = new Vector2(this.x, this.y);
        Debug.DrawLine(vectorInicial, vectorFinal);
    }
    public void Draw(Color color)
    {
        Vector2 vectorInicial = new Vector2(0, 0);
        Vector2 vectorFinal = new Vector2(this.x, this.y);
        Debug.DrawLine(vectorInicial, vectorFinal,color);
    }
    public void Draw(Vectores puntoInicio)
    {
        Vector2 vectorInicial = new Vector2(puntoInicio.x, puntoInicio.y);
        Vector2 vectorFinal = new Vector2(this.x+puntoInicio.x, this.y+puntoInicio.y);
        Debug.DrawLine(vectorInicial, vectorFinal);
    }
    public void Draw(Vectores puntoInicio,Color color)
    {
        Vector2 vectorInicial = new Vector2(puntoInicio.x, puntoInicio.y);
        Vector2 vectorFinal = new Vector2(this.x + puntoInicio.x, this.y + puntoInicio.y);
        Debug.DrawLine(vectorInicial, vectorFinal,color);
    }
    public float Magnitud()
    {
        float c;
        c = this.x * this.x + this.y * this.y;
        c = Mathf.Sqrt(c);
        return c;
    }
    public Vectores Normalizar()
    {
        Vectores c = new Vectores();
        float d;
        d = 1 / this.Magnitud();
        return c*d;
    }
    public Vectores Lerp(Vectores b,float escalar)
    {
        Vectores c = new Vectores();
        c = this + (b - this) * escalar;
        return c;
    }
    public override string ToString()
    {
        return "(" + this.x + ", " + this.y + ")";
    }
    public static Vectores operator + (Vectores a,Vectores b)
    {
        return new Vectores(a.x + b.x, a.y + b.y);
    }
    public static Vectores operator - (Vectores a, Vectores b)
    {
        return new Vectores(a.x - b.x, a.y - b.y);
    }
    public static Vectores operator * (Vectores a, float escalar)
    {
        return new Vectores(a.x * escalar, a.y * escalar);
    }
    public static Vectores operator * (float escalar,Vectores a)
    {
        return new Vectores(a.x * escalar, a.y * escalar);
    }
    public static Vectores operator /(Vectores a, float escalar)
    {
        return new Vectores(a.x / escalar, a.y / escalar);
    }
}
