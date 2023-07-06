using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField] private Personaje _personaje;
    [SerializeField] private TextMeshProUGUI _textVida;
    [SerializeField] private TextMeshProUGUI  _textKills;


    private void Start()
    {
        _textVida.text = _personaje.Vida.ToString();    
        _textKills.text = "0"; 
    }
}
