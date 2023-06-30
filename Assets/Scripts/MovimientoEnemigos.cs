using System;
using UnityEngine;
using UnityEngine.AI;


public class MovimientoEnemigos : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _velocidad;
    [SerializeField] private NavMeshAgent _agent;

    [SerializeField] private PosicionDelJugador _posicionDelJugador;


    private void Update()
    {
        Mover();
    }

    private void Mover()
    {

        if(_posicionDelJugador.Posicion != Vector3.zero)
        {
            _agent.destination = _posicionDelJugador.Posicion;
        }
    }   
}