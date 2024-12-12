using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // En este script se trabajaran los botones del menú y las animaciones principales
    [SerializeField]
    GameObject tituloJuego;
    [SerializeField]
    GameObject enterJuego;
    [SerializeField]
    GameObject menuJuego;
    [SerializeField]
    GameObject botonNuevaPartida;
    [SerializeField]
    GameObject botonContinuar;
    [SerializeField]
    GameObject botonOpciones;
    [SerializeField]
    GameObject botonSalir;
    [SerializeField]
    GameObject canvasInicio;
    [SerializeField]
    GameObject canvasPartida;
    [SerializeField]
    GameObject nave;
    //Array para las naves
    [SerializeField]
    public GameObject[] naves;
    //Posicion para la nave
    [SerializeField]
    Vector3 posicionNave;
    //Parametros
    [SerializeField]
    float posicionTitulo;
    [SerializeField]
    float tiempoAnimacion;
    [SerializeField]
    LeanTweenType animCurv;
    [SerializeField]
    float posicionMenu;
    [SerializeField]
    Vector3 rotacionInicialNave;
    [SerializeField]
    Vector3 scaladoNave;
    //Booleanos 
    [SerializeField]
    bool comienzaElJuego;
    [SerializeField]
    bool tiempo;
    [SerializeField]
    bool eleccionPersonaje;
    void Start()
    {
        //booleanos
        comienzaElJuego = false;
        tiempo= false;
        eleccionPersonaje = false;
        //Canvas
        canvasPartida.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (comienzaElJuego == false && Input.GetButtonDown("Submit"))
        {
            comienzaElJuego=true;
            enterJuego.SetActive(false);
            botonContinuar.SetActive(false);
            LeanTween.moveLocalY(tituloJuego,posicionTitulo,tiempoAnimacion).setEase(animCurv);
            LeanTween.moveLocalY(menuJuego, posicionMenu, tiempoAnimacion).setEase(animCurv).setOnComplete(()=>{
                LeanTween.moveLocalY(botonNuevaPartida, -68.9541f, tiempoAnimacion+0.2f).setEase(animCurv).setOnComplete(() => { //152.9541f
                    LeanTween.moveLocalY(botonOpciones, -212f, tiempoAnimacion + 0.2f).setEase(animCurv).setOnComplete(() => { //8
                        LeanTween.moveLocalY(botonSalir,-356, tiempoAnimacion + 0.2f).setEase(animCurv);
                    });
                });
       
            });
        }
        if (eleccionPersonaje == true)
        { 
            
        }
        /*if (comienzaElJuego == true && Input.GetButtonDown("Cancel"))
        {
            Debug.Log("escape");
            if (canvasMenu.activeSelf)
            {
                HidePopUp();
            }
            else
            {
                ShowPopUp();
            }
        }*/
    }
    public void NuevaPartida()
    {
        canvasPartida.SetActive(true);
        eleccionPersonaje = true;
        canvasInicio.SetActive(false);
        int naveCreada=Random.Range(0,naves.Length);
        nave =Instantiate(naves[naveCreada], posicionNave, Quaternion.identity);
        nave.transform.Rotate(rotacionInicialNave);
        //nave.transform.localScale = scaladoNave;
    }
}
