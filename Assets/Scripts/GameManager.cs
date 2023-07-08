using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance { get => _instance; }

    [SerializeField] private Personaje _personaje;
    [SerializeField] private TextMeshProUGUI _textVida;
    [SerializeField] private TextMeshProUGUI _textKills;
 
    private int _puntuacion = 0;


    private void Start()
    {
        ControlarSiLaInstanciaEsUnica();
    }

    private void ControlarSiLaInstanciaEsUnica()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        ActualizarUI();
        ControlarEstadoJuego();
    }

    private void ControlarEstadoJuego()
    {
        if(_personaje.Vida <= 0)
        {
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
    }

    private void ActualizarUI()
    {
        _textVida.text = _personaje.Vida.ToString();
        _textKills.text = _puntuacion.ToString();
    }


    public void AumentarPuntuacion()
    {
        _puntuacion++;
    }
}