using System;
using UnityEngine;


public class ColisionBala : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Arbol"))
        {
            DestruirBala();
        }
    }

    private void DestruirBala()
    {
        Destroy(this.gameObject);
    }
}
