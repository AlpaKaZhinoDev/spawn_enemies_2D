using UnityEngine;


public class Personaje : MonoBehaviour
{
    [SerializeField] private PosicionDelJugador _miPosicion;
    [SerializeField] private MaquinaDeEstadosPersonaje _estadoActual;

    [Header("Ataque")]
    [SerializeField] private Transform _puntoDeDisparo;
    [SerializeField] private GameObject _prefabBala;
    [SerializeField] private float _tiempoEntreDisparos;
    private float _tiempoTranscurrido = 5f;

    private void Update()
    {
        ActualizarMiPosicion();
        Atacar();
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