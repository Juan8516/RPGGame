using UnityEngine;

public class PersonajeExperiencia : MonoBehaviour
{
    [SerializeField] private int nivelMax = 10;
    [SerializeField] private int expBase = 10;
    [SerializeField] private int valorIncremental = 2;

    public int Nivel { get; private set; }

    private float expActualTemp;
    private float expRequeridaSiguienteNivel;

    private void Start()
    {
        Nivel = 1;
        expActualTemp = 0f;
        expRequeridaSiguienteNivel = expBase;
        ActualizarBarraExp();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            AñadirExperiencia(2f);
        }
    }

    public void AñadirExperiencia(float expObtenida)
    {
        if (expObtenida <= 0f) return;

        expActualTemp += expObtenida;

        // Mientras tenga suficiente experiencia para subir de nivel
        while (expActualTemp >= expRequeridaSiguienteNivel && Nivel < nivelMax)
        {
            expActualTemp -= expRequeridaSiguienteNivel;
            Nivel++;

            // Calcula la nueva experiencia requerida
            expRequeridaSiguienteNivel = expBase + (valorIncremental * (Nivel - 1));
        }

        Debug.Log($"Nivel: {Nivel} | Exp actual: {expActualTemp}/{expRequeridaSiguienteNivel}");

        ActualizarBarraExp();
    }

    private void ActualizarNivel()
    {
        if(Nivel < nivelMax)
        {
            Nivel++;
            expActualTemp = 0f;
            expRequeridaSiguienteNivel *= valorIncremental;
        }
    }

    private void ActualizarBarraExp()
    {
        UIManager.Instance.ActualizarExpPersonaje(expActualTemp, expRequeridaSiguienteNivel);
    }
}

