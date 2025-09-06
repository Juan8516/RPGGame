using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class movimientoPersonaje : MonoBehaviour
{
    [SerializeField] private float _velocidad;

    public bool enMovimiento => _direccionMovimiento.magnitude > 0f;
    public Vector2 DireccionMovimiento => _direccionMovimiento;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _direccionMovimiento;
    private Vector2 _input;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _input = new Vector2(x:Input.GetAxisRaw("Horizontal"), y:Input.GetAxisRaw("Vertical"));

        //Movimiento de personaje en X (horizontal)
        if(_input.x > 0.1f)
        {
            _direccionMovimiento.x = 1f;
        } 
        else if (_input.x < 0f)
        {
            _direccionMovimiento.x = -1f;
        }
        else 
        {
            _direccionMovimiento.x = 0f;
        }

        //Movimiento de personaje en Y (vertical)
        if (_input.y > 0.1f)
        {
            _direccionMovimiento.y = 1f;
        }
        else if (_input.y < 0f)
        {
            _direccionMovimiento.y = -1f;
        }
        else
        {
            _direccionMovimiento.y = 0f;
        }
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _direccionMovimiento * _velocidad * Time.fixedDeltaTime);
    }
}
