using System;
using UnityEngine;


public class MaquinaDeEstadosPersonaje : MonoBehaviour
{
    [SerializeField] private Animator _animator;


    private Estado _estadoActual;

    public Estado EstadoActual { get => _estadoActual; set => _estadoActual = value; }

    private void Start()
    {
        _estadoActual = Estado.Idle;    
    }

    private void Update()
    {
        ControlarEntradaDelUsuario();
        ControlarEstado();
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