using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulasBala : MonoBehaviour
{
    [SerializeField] private GameObject _particulasMuerte;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemigo"))
        {
            GameManager.Instance.AumentarPuntuacion();
        }
        if(other.gameObject.CompareTag("Arbol") || other.gameObject.CompareTag("Enemigo"))
        {
            Instantiate(_particulasMuerte, transform.position + new Vector3(0f,5f,0f), Quaternion.identity);

            gameObject.SetActive(false);


            Invoke("Destruir", 2f);
        }
    }

    private void Destruir()
    {
        Destroy(gameObject);
    }
}
