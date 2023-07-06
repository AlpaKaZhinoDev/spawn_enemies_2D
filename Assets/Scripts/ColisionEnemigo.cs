using UnityEngine;


public class ColisionEnemigo : MonoBehaviour
{
    private void Start()
    {
        Invoke("Destruir", 3f);    
    }

    private void Destruir()
    {
        Destroy(gameObject);
    }
}