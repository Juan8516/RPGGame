using System;
using UnityEngine;

public class PersonajeVida: VidaBase
{
    public static Action EventoPersonajeDerrotado;
    public bool PuedeSerCurado => Salud < saludMax;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            RecibirDaño(10);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestaurarSalud(10);
        }
    }
    public void RestaurarSalud(float cantidad)
    {
        if(PuedeSerCurado)
        {
            Salud += cantidad;
            if (Salud > saludMax)
            {
                Salud = saludMax;
            }

            ActualizarBarraVida(Salud, saludMax);
            PersonajeDerrotado();
        }
    }


    protected override void PersonajeDerrotado()
    {
        EventoPersonajeDerrotado?.Invoke();
    }

    override protected void ActualizarBarraVida(float vidaActual, float vidaMaxima)
    {
        
    }
}

