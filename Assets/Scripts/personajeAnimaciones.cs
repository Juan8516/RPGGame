using UnityEngine;

public class personajeAnimaciones : MonoBehaviour
{
    private Animator _animator;
    private movimientoPersonaje _movimientoPersonaje;

    private readonly int direccionX = Animator.StringToHash(name:"X");
    private readonly int direccionY = Animator.StringToHash(name:"Y");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _movimientoPersonaje = GetComponent<movimientoPersonaje>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_movimientoPersonaje.enMovimiento == false)
        {
            return;
        }

        _animator.SetFloat(direccionX, _movimientoPersonaje.DireccionMovimiento.x);
        _animator.SetFloat(direccionY, _movimientoPersonaje.DireccionMovimiento.y);
    }
}
