using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuOpciones : MonoBehaviour
{
    [SerializeField]
    private AudioMixer musica;

    [SerializeField]
    private AudioMixer efectosDeSonido;
    //Pantalla completa
    public void PantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }
    //Controlador del volumen
    public void CambiarVolumen(float volumen)
    {
        musica.SetFloat("Musica", volumen);
    }
    public void CambiarVolumenEfectos(float volumen)
    {
        efectosDeSonido.SetFloat("Efectos De Sonido", volumen);
    }
}
