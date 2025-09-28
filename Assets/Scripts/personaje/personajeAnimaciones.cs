using UnityEngine;

public class personajeAnimaciones : MonoBehaviour
{
    [SerializeField] private string layerIdle;
    [SerializeField] private string layerCaminar;

    
    private Animator _animator;
    private movimientoPersonaje _movimientoPersonaje;

    private readonly int direccionX = Animator.StringToHash(name:"X");
    private readonly int direccionY = Animator.StringToHash(name:"Y");
    private readonly int derrotado = Animator.StringToHash(name:"Derrotado");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _movimientoPersonaje = GetComponent<movimientoPersonaje>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        ActualizarLayer();

        if (_movimientoPersonaje.enMovimiento == false)
        {
            return;
        }

        _animator.SetFloat(direccionX, _movimientoPersonaje.DireccionMovimiento.x);
        _animator.SetFloat(direccionY, _movimientoPersonaje.DireccionMovimiento.y);
    }

    private void ActivarLeyer(string nombreLayer)
    {
        for(int i = 0; i < _animator.layerCount; i++)
        {
            _animator.SetLayerWeight(i, 0f);
        }

        _animator.SetLayerWeight(_animator.GetLayerIndex(nombreLayer), 1f);
    }

    private void ActualizarLayer()
    {
        if(_movimientoPersonaje.enMovimiento)
        {
            ActivarLeyer(layerCaminar);
        }
        else
        {
            ActivarLeyer(layerIdle);
        }
    }

    public void RevivirPersonaje()
    {
        ActivarLeyer(layerIdle);
        _animator.SetBool(derrotado, false);
    }

    private void personajeDerrotadoRespuesta()
    {
        if(_animator.GetLayerWeight(_animator.GetLayerIndex(layerIdle)) == 1f)
        {
            _animator.SetBool(derrotado, true);
        }
    }

    private void OnEnable()
    {
        PersonajeVida.EventoPersonajeDerrotado += personajeDerrotadoRespuesta;
    }

    private void OnDisable()
    {
        PersonajeVida.EventoPersonajeDerrotado -= personajeDerrotadoRespuesta;
    }
}
