using System;
using UnityEngine;


public class MaquinaDeEstadosPersonaje : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _velocidad;

    private Estado _estadoActual;
    public Estado EstadoActual { get => _estadoActual; set => _estadoActual = value; }

    private Vector3 _direction;


    private void Start()
    {
        _estadoActual = Estado.Idle;    
    }

    private void Update()
    {
        ControlarEntradaDelUsuario();
        ControlarEstado();
    }

    private void FixedUpdate()
    {
        Mover();
    }

    private void Mover()
    {
        _rigidbody.MovePosition(transform.position + (_direction * (_velocidad * Time.fixedDeltaTime)));
    }

    private void ControlarEntradaDelUsuario()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            _estadoActual = Estado.Attack;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            _estadoActual = Estado.Idle;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        _direction = new Vector3(horizontal, 0f, vertical).normalized;
    }

    private void ControlarEstado()
    {
        switch (_estadoActual)
        {
            case Estado.Idle:
                _animator.SetBool("EnAtaque", false);
                _animator.SetBool("EnMovimiento", false);
            break;
            case Estado.Walk:
                _animator.SetBool("EnMovimiento", true);
            break;
            case Estado.Attack:
                _animator.SetBool("EnAtaque", true);
            break;
        }
    }
}