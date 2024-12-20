using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour
{
    public static Canvas Instance;
    [SerializeField]
    GameObject canvasEnter;
    [SerializeField]
    GameObject botonNuevaPartida;
    [SerializeField]
    GameObject botonContinuar;
    [SerializeField]
    GameObject botonOpciones;
    [SerializeField]
    GameObject botonSalir;
    [SerializeField]
    GameObject tituloComenzar;
    [SerializeField]
    GameObject enterJuego;
    [SerializeField]
    GameObject menuJuego;
    //Parametros
    [SerializeField]
    float posicionTitulo;
    [SerializeField]
    float tiempoAnimacion;
    [SerializeField]
    LeanTweenType animCurv;
    [SerializeField]
    float posicionMenu;
    //Posiciones en las pantallas
    /*[SerializeField]
    float posPantallaInicio;*/
    [SerializeField]
    float posPantallaNuevaPartida = -68.9541f;
    /*[SerializeField]
    float posPantallaContinuar = -999;*/
    [SerializeField]
    float posPantallaOpciones = -212;
    [SerializeField]
    float posPantallaSalir = -356;
    //Posiciones fuera de pantalla
    [SerializeField]
    float posInicio = -694;
    [SerializeField]
    float posNuevaPartida = -897;
    [SerializeField]
    float posContinuar = -999;
    [SerializeField]
    float posOpciones = -1103;
    [SerializeField]
    float posSalir = -1206;
    //Transformaciones de la nave
    [SerializeField]
    public Vector3 rotacionInicialNave;
    [SerializeField]
    public Vector3 posicionNave;
    //Naves
    [SerializeField]
    public GameObject[] naves;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            canvasEnter.SetActive(false);
            enterJuego.SetActive(false);
            botonContinuar.SetActive(true);
            LeanTween.moveLocalY(tituloComenzar, posicionTitulo, tiempoAnimacion).setEase(animCurv);
            LeanTween.moveLocalY(menuJuego, posicionMenu, tiempoAnimacion).setEase(animCurv).setOnComplete(() => {
                LeanTween.moveLocalY(botonNuevaPartida, posPantallaNuevaPartida, tiempoAnimacion + 0.1f).setEase(animCurv).setOnComplete(() => { //152.9541f
                    LeanTween.moveLocalY(botonOpciones, posPantallaOpciones, tiempoAnimacion + 0.1f).setEase(animCurv).setOnComplete(() => { //8
                        LeanTween.moveLocalY(botonSalir, posPantallaSalir, tiempoAnimacion + 0.1f).setEase(animCurv);
                    });
                });
            });
        }
    }
    public void NuevaPartida()
    { 
     //Poner la otra escena sin el canvas <- Eleccion de personajes
    }
}
