using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


public class GeneracionDeEnemigos : MonoBehaviour
{
    [SerializeField] private Transform[] _puntosDeAparicion;

    [SerializeField] private GameObject[] _prefabsEnemigo;


    private void Start()
    {
        Invoke("ComenzarCorrutina", 3f);
    } 

    IEnumerator GenerarEnemigo()
    {   
        while(true)
        {
            Vector3 posicionDeSpawn = SeleccionarPosicionAleatoria();

            Instantiate(_prefabsEnemigo[ElegirEnemigoAleatorio()], posicionDeSpawn, Quaternion.identity);

            yield return new WaitForSeconds(10f);
        }
    }


    private void ComenzarCorrutina()
    {
        StartCoroutine("GenerarEnemigo");
    }

    private int ElegirEnemigoAleatorio()
    {
        return Random.Range(0, _prefabsEnemigo.Length);
    }

    private Vector3 SeleccionarPosicionAleatoria()
    {
        int puntoAleatorio = Random.Range(0, _puntosDeAparicion.Length);

        return _puntosDeAparicion[puntoAleatorio].transform.position;
    }
}