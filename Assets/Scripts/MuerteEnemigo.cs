using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteEnemigo : MonoBehaviour
{
    [SerializeField] private GameObject _particulasMuerte;

    private void OnCollisionEnter(Collision other)
    {
        Instantiate(_particulasMuerte, transform);

        Invoke("Destruir", 2f);
    }

    private void Destruir()
    {
        Destroy(gameObject);
    }

}
