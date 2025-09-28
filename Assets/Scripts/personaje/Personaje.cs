using UnityEngine;

public class Personaje : MonoBehaviour
{
    public PersonajeVida PersonajeVida { get; private set; }
    public personajeAnimaciones PersonajeAnimaciones { get; private set; }

    private void Awake()
    {
        PersonajeVida = GetComponent<PersonajeVida>();
        PersonajeAnimaciones = GetComponent<personajeAnimaciones>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestaurarPersonaje()
    {
        PersonajeVida.RestaurarPersonaje();
        PersonajeAnimaciones.RevivirPersonaje();
    }
}
