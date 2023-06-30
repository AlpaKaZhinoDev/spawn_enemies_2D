using UnityEngine;


[CreateAssetMenu(menuName = "PosicionDelJugador")]
public class PosicionDelJugador : ScriptableObject
{
    private Vector3 _posicion;

    public Vector3 Posicion { get => _posicion; set => _posicion = value; }
}
