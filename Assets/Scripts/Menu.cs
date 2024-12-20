using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public static Menu Instance;
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
    GameObject botonVolver;
    [SerializeField]
    GameObject canvasInicio;
    [SerializeField]
    GameObject canvasPartida;
    [SerializeField]
    GameObject nave;
    [SerializeField]
    GameObject menuOpciones;
    //Array para las naves
    [SerializeField]
    public GameObject[] naves;
    //Posicion para la nave
    [SerializeField]
    public Vector3 posicionNave;
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
    public Vector3 rotacionInicialNave;
    [SerializeField]
    Vector3 scaladoNave;
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
    float posInicio=-694;
    [SerializeField]
    float posNuevaPartida=-897;
    [SerializeField]
    float posContinuar=-999;
    [SerializeField]
    float posOpciones=-1103;
    [SerializeField]
    float posSalir=-1206;
    //Booleanos 
    [SerializeField]
    bool comienzaElJuego;
    [SerializeField]
    public bool tiempo;
    [SerializeField]
    bool eleccionPersonaje;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
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
                LeanTween.moveLocalY(botonNuevaPartida, posPantallaNuevaPartida, tiempoAnimacion+0.1f).setEase(animCurv).setOnComplete(() => { //152.9541f
                    LeanTween.moveLocalY(botonOpciones, posPantallaOpciones, tiempoAnimacion + 0.1f).setEase(animCurv).setOnComplete(() => { //8
                        LeanTween.moveLocalY(botonSalir,posPantallaSalir, tiempoAnimacion + 0.1f).setEase(animCurv);
                    });
                });
            });
        }
        if (comienzaElJuego == true && Input.GetButtonDown("Cancel"))
        {
            Debug.Log("escape");
            if (canvasInicio.activeSelf)
            {
                HidePopUp();
            }
            else
            {
                ShowPopUp();
            }
        }
    }
    public void HidePopUp()
    { 
        canvasInicio.SetActive(false);
    }
    public void ShowPopUp()
    {
        canvasInicio.SetActive(true);
        tiempo = false;
    }
    public void NuevaPartida()
    {
        canvasPartida.SetActive(true);
        eleccionPersonaje = true;
        tiempo = true;
        canvasInicio.SetActive(false);
        Destroy(nave);
        int naveCreada=Random.Range(0,naves.Length);
        nave =Instantiate(naves[naveCreada], posicionNave, Quaternion.identity);
        nave.transform.Rotate(rotacionInicialNave);
    }
    public void Continuar()
    {
        tiempo = true;
    }
    public void Opciones()
    {
        LeanTween.moveLocalY(menuJuego, posInicio, tiempoAnimacion + 0.1f).setEase(animCurv).setOnComplete(() => {
            LeanTween.moveLocalY(botonNuevaPartida, posNuevaPartida, tiempoAnimacion).setEase(animCurv).setOnComplete(() => { //152.9541f
                LeanTween.moveLocalY(botonOpciones, posOpciones, tiempoAnimacion).setEase(animCurv).setOnComplete(() => { //8
                    LeanTween.moveLocalY(botonSalir, posSalir, tiempoAnimacion).setEase(animCurv);
                });
            });
        });

        //Para que salgan los botones de Opciones
        LeanTween.moveLocalY(menuOpciones, posicionMenu, tiempoAnimacion + 0.1f).setEase(animCurv).setOnComplete(() => {
             LeanTween.moveLocalY(botonVolver, -506, tiempoAnimacion + 0.6f).setEase(animCurv);
        });
        //Crear boton para volver, opcion menu pantalla completa y los sliders para el sonido
    }
    public void Volver()
    {
        //Poner el menu en la pantalla
        LeanTween.moveLocalY(menuJuego, posicionMenu, tiempoAnimacion).setEase(animCurv).setOnComplete(() => {
            LeanTween.moveLocalY(botonNuevaPartida, posPantallaNuevaPartida, tiempoAnimacion + 0.1f).setEase(animCurv).setOnComplete(() => { //152.9541f
                LeanTween.moveLocalY(botonOpciones, posPantallaOpciones, tiempoAnimacion + 0.1f).setEase(animCurv).setOnComplete(() => { //8
                    LeanTween.moveLocalY(botonSalir, posPantallaSalir, tiempoAnimacion + 0.1f).setEase(animCurv);
                });
            });
        });
        //Para ocultar los botones de Opciones
        LeanTween.moveLocalY(menuOpciones, posInicio, tiempoAnimacion + 0.1f).setEase(animCurv).setOnComplete(() => {
            LeanTween.moveLocalY(botonVolver, posSalir, tiempoAnimacion + 0.1f).setEase(animCurv);
        });
    }
    public void Salir()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
