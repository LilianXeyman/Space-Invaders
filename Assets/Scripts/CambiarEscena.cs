using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    //Para cambiar de escena (pones el nombre de la escena a la que vas a cambiar)
    public string partida;
    [SerializeField]
    GameObject pantallaDeCarga;
    private void Start()
    {
        pantallaDeCarga.SetActive(false);
    }
    //Cuando colisione el proyectil con las naves cambia de escena
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Proyectil"))
        { 
            pantallaDeCarga.SetActive(true);
            SceneManager.LoadScene(partida);
        }
    }
}
