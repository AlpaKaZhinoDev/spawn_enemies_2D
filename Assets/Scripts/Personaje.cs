using UnityEngine;


public class Personaje : MonoBehaviour
{
    [SerializeField] PosicionDelJugador _miPosicion;

    private void Update()
    {
        ActualizarMiPosicion();
    }

    private void ActualizarMiPosicion()
    {
        _miPosicion.Posicion = transform.position;    
    }
}