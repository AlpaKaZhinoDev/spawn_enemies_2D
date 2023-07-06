using System;
using UnityEngine;


public class Personaje : MonoBehaviour
{
    [SerializeField] private PosicionDelJugador _miPosicion;
    [SerializeField] private MaquinaDeEstadosPersonaje _estadoActual;

    [Header("Ataque")]
    [SerializeField] private Transform _puntoDeDisparo;
    [SerializeField] private GameObject _prefabBala;
    [SerializeField] private float _tiempoEntreDisparos;
    [SerializeField] private Rigidbody _rigidbody;

    private int _vida = 3;
    public int Vida { get=> _vida; set => _vida = value;}


    private float _tiempoTranscurrido = 5f;

    private Camera _camaraPrincipal;


    private void Start()
    {
        _camaraPrincipal = Camera.main;
    }


    private void Update()
    {
        ActualizarMiPosicion();
        Atacar();
        MirarAlMouse();
    }

    private void MirarAlMouse()
    {
        Ray ray = _camaraPrincipal.ScreenPointToRay(Input.mousePosition);
        
        Plane plano = new Plane(Vector3.up, Vector3.zero);
        
        float distance;

        if (plano.Raycast(ray, out distance))
        {
            Vector3 target = ray.GetPoint(distance);
            
            Vector3 direction = target - transform.position;
            
            float rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            
            var rotacionFinal = Quaternion.Euler(0, rotation, 0);
            _rigidbody.MoveRotation(rotacionFinal);
        }
    }

    private void Atacar()
    {
        _tiempoTranscurrido += Time.deltaTime;

        if(_estadoActual.EstadoActual == Estado.Attack && _tiempoTranscurrido > _tiempoEntreDisparos)
        {
            _tiempoTranscurrido = 0f;

            Instantiate(_prefabBala, _puntoDeDisparo.position, _puntoDeDisparo.rotation);           
        }          
    }

    private void ActualizarMiPosicion()
    {
        _miPosicion.Posicion = transform.position;    
    }
}