using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct Vectores 
{
    public float x, y;
    public Color color;
    public Vectores SumarVectores(Vectores vector1,Vectores vector2)
    {
        Vectores c = new Vectores();
        c.x = vector1.x + vector2.x;
        c.y = vector1.y + vector2.y;
        c.color = vector1.color + vector2.color;
        return c;
    }
    public Vectores RestarVectores(Vectores vector1, Vectores vector2)
    {
        Vectores c = new Vectores();
        c.x = vector1.x - vector2.x;
        c.y = vector1.y - vector2.y;
        c.color = vector1.color + vector2.color;
        return c;
    }
    public Vectores MultVectores(Vectores vector,float escalar)
    {
        Vectores c = new Vectores();
        c.x = vector.x * escalar;
        c.y = vector.y * escalar;
        c.color = Color.yellow;
        return c;
    }
    public void Draw()
    {
        Vector2 vectorInicial = new Vector2(0, 0);
        Vector2 vectorFinal = new Vector2(this.x, this.y);
        Debug.DrawLine(vectorInicial, vectorFinal,this.color);
    }
    public void Draw(Vectores puntoInicio)
    {
        Vector2 vectorInicial = new Vector2(puntoInicio.x, puntoInicio.y);
        Vector2 vectorFinal = new Vector2(this.x+puntoInicio.x, this.y+puntoInicio.y);
        Debug.DrawLine(vectorInicial, vectorFinal,this.color);
    }
    public float Magnitud()
    {
        float c;
        c = this.x * this.x + this.y * this.y;
        c = Mathf.Sqrt(c);
        return c;
    }
    public override string ToString()
    {
        return "(" + this.x +", "+this.y + ")";
    }
    public Vectores Normalizar()
    {
        Vectores c = new Vectores();
        float d;
        d = 1 / this.Magnitud();
        c.x = this.x *d;
        c.y = this.y * d;
        c.color = Color.white;

        return c;
    }
    public Vectores Lerp(Vectores final,float escalar)
    {
        Vectores c = new Vectores();
        c = SumarVectores(this,c.MultVectores(c.RestarVectores(final,this),escalar));
        c.color = Color.blue;
        return c;
    }
    

    
}
