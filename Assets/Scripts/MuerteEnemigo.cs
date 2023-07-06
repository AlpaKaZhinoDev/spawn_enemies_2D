using UnityEngine;


public class MuerteEnemigo : MonoBehaviour
{
    [SerializeField] private GameObject _particulasMuerte;

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Bala"))
        {
            MostrarParticulas();
            Invoke("Destruir", 2f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bala"))
        {
            MostrarParticulas();
            Invoke("Destruir", 2f);    
        }
    }

    private void MostrarParticulas()
    {
        Instantiate(_particulasMuerte, transform.position + new Vector3(0f,5f,0f), Quaternion.identity);
        gameObject.SetActive(false);
    }

    private void Destruir()
    {
        Destroy(gameObject);
    }
}