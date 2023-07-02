using UnityEngine;

public class MovimietoBala : MonoBehaviour
{
    [SerializeField] private float _velocidad;

    private void Update()
    {
        transform.position += transform.forward * _velocidad * Time.deltaTime;
    }
}
