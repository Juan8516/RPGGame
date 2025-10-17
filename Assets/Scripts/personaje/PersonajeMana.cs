using UnityEngine;

public class PersonajeMana : MonoBehaviour
{
    [SerializeField] private float manaInicial;
    [SerializeField] private float manaMax;
    [SerializeField] private float regeneracionPorSegundo;

    public float ManaActual { get; private set; }

    private PersonajeVida _personajeVida;

    private void Awake()
    {
        _personajeVida = GetComponent<PersonajeVida>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ManaActual = manaInicial;
        ActializarBarraMana();

        InvokeRepeating(nameof(RegenerarMana), 1, 1);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            UsarMana(10f);
        }
    }

    public void UsarMana(float cantidad)
    {
        if(ManaActual >= cantidad)
        {
            ManaActual -= cantidad;
            ActializarBarraMana();
        }
    }

    private void RegenerarMana()
    {
        if(_personajeVida.Salud > 0f && ManaActual < manaMax)
        {
            ManaActual += regeneracionPorSegundo;
            ActializarBarraMana();
        }
    }

    public void RestablecerMana()
    {
        ManaActual = manaInicial;
        ActializarBarraMana();
    }

    private void ActializarBarraMana()
    {
        UIManager.Instance.ActualizarManaPersonaje(ManaActual, manaMax);
    }

}
