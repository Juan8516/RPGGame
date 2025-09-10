using UnityEngine;

public class VidaBase : MonoBehaviour
{
    [SerializeField] protected float saludInicial;
    [SerializeField] protected float saludMax;

    public float Salud { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Salud = saludInicial;
    }

    public void RecibirDa�o(float cantidad)
    {
        if(Salud <= 0)
        {
            return;
        }

        if(Salud >= 0f)
        {
            Salud -= cantidad;
            ActualizarBarraVida(Salud, saludMax);
            if(Salud <= 0f)
            {
                ActualizarBarraVida(Salud, saludMax);
                PersonajeDerrotado();
            }
        }
    }

    protected virtual void ActualizarBarraVida(float vidaActual, float vidaMaxima)
    {

    }

    protected virtual void PersonajeDerrotado()
    {

    }
}
