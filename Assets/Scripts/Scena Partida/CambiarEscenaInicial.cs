using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscenaInicial : MonoBehaviour
{
    //Para cambiar de escena (pones el nombre de la escena a la que vas a cambiar)
    public string SampleScene;
    private void Start()
    {

    }
    //Cuando colisione el proyectil con las naves cambia de escena
    public void Reintentar()
    {
         SceneManager.LoadScene(SampleScene);
    }
}
