using UnityEngine;


public class ColisionEnemigo : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            DestruirEnemigo();
        }    
    }

    private void DestruirEnemigo()
    {
        Destroy(this.gameObject);
    }
}