using System;
using UnityEngine;


public class MaquinaDeEstadosPersonaje : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _velocidad;

    [SerializeField] private Estado _estadoActual;
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
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        _direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(horizontal == 0f && vertical == 0)
        {
            _estadoActual = Estado.Idle;
        }
        else
        {
            _estadoActual = Estado.Walk;
        }

        Atacar();
    }

    private void Atacar()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _estadoActual = Estado.Attack;
        }
        if(Input.GetMouseButtonUp(0))
        {
            _estadoActual = Estado.Idle;
        }
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
                _animator.SetBool("EnAtaque", false);
            break;
            case Estado.Attack:
                _animator.SetBool("EnAtaque", true);
                _animator.SetBool("EnMovimiento", false);
            break;
        }
    }
}