using UnityEngine;

public class MovimietoBala : MonoBehaviour
{
    [SerializeField] private float _velocidad;

    private void Update()
    {
        transform.position += Vector3.forward * _velocidad * Time.deltaTime;
    }
}
