using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour
{
    public static Canvas Instance;
    [SerializeField]
    GameObject canvasEnter;
    [SerializeField]
    GameObject canvasPausa;
    [SerializeField]
    GameObject canvasEnPartida;
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
    GameObject barraOpciones;
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
    [SerializeField]
    float posPantallaContinuar = -999;
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
    //Bolenos
    public bool estaJugando;
    //Para la pantalla de opciones
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
    // Start is called before the first frame update
    void Start()
    {
        Menu.Instance.tiempo= true;
        estaJugando = false;
        canvasPausa.SetActive(false);
        canvasEnter.SetActive(true);
        canvasEnPartida.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            estaJugando=true;
            canvasEnter.SetActive(false);
            enterJuego.SetActive(false);
            canvasEnPartida.SetActive(true);
            botonContinuar.SetActive(true);
            LeanTween.moveLocalY(tituloComenzar, posicionTitulo, tiempoAnimacion).setEase(animCurv);
            LeanTween.moveLocalY(menuJuego, posicionMenu, tiempoAnimacion).setEase(animCurv).setOnComplete(() => {
                LeanTween.moveLocalY(botonNuevaPartida, posPantallaNuevaPartida, tiempoAnimacion + 0.1f).setEase(animCurv).setOnComplete(() => { //152.9541f
                    LeanTween.moveLocalY(botonContinuar, posPantallaContinuar, tiempoAnimacion + 0.1f).setEase(animCurv).setOnComplete(() => {
                        LeanTween.moveLocalY(botonOpciones, posPantallaOpciones, tiempoAnimacion + 0.1f).setEase(animCurv).setOnComplete(() => { //8
                             LeanTween.moveLocalY(botonSalir, posPantallaSalir, tiempoAnimacion + 0.1f).setEase(animCurv);
                        });
                    });
                });
            });
        }
        if (Input.GetButtonDown("Cancel"))
        {
            if (canvasPausa.activeSelf)
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
        canvasPausa.SetActive(false);
        LeanTween.moveLocalY(menuJuego, posInicio, tiempoAnimacion + 0.1f).setEase(animCurv);
        LeanTween.moveLocalY(botonNuevaPartida, posNuevaPartida, tiempoAnimacion - 0.1f).setEase(animCurv);
        LeanTween.moveLocalY(botonContinuar, posContinuar, tiempoAnimacion - 0.1f).setEase(animCurv);
        LeanTween.moveLocalY(botonOpciones, posOpciones, tiempoAnimacion - 0.1f).setEase(animCurv);
        LeanTween.moveLocalY(botonSalir, posSalir, tiempoAnimacion - 0.1f).setEase(animCurv);
        //Para que salgan los botones de Opciones
        LeanTween.moveLocalY(barraOpciones, posicionMenu, tiempoAnimacion + 0.1f).setEase(animCurv);
        LeanTween.moveLocalY(botonVolver, -506, tiempoAnimacion + 0.8f).setEase(animCurv);
        estaJugando = true;
    }
    public void ShowPopUp()
    {
        //Poner el menu en la pantalla
        LeanTween.moveLocalY(menuJuego, posicionMenu, tiempoAnimacion).setEase(animCurv);
        LeanTween.moveLocalY(botonNuevaPartida, posPantallaNuevaPartida, tiempoAnimacion + 0.1f).setEase(animCurv);
        LeanTween.moveLocalY(botonContinuar, posPantallaContinuar, tiempoAnimacion + 0.1f).setEase(animCurv);
        LeanTween.moveLocalY(botonOpciones, posPantallaOpciones, tiempoAnimacion + 0.1f).setEase(animCurv);
        LeanTween.moveLocalY(botonSalir, posPantallaSalir, tiempoAnimacion + 0.1f).setEase(animCurv);

        //Para ocultar los botones de Opciones
        LeanTween.moveLocalY(barraOpciones, posInicio, tiempoAnimacion + 0.1f).setEase(animCurv);
        LeanTween.moveLocalY(botonVolver, posSalir, tiempoAnimacion + 0.1f).setEase(animCurv);

        canvasPausa.SetActive(true);
        estaJugando = false;
    }
    public void NuevaPartida()
    { 
     //Poner la otra escena sin el canvas <- Eleccion de personajes
    }
    public void Continuar()
    {
        Debug.Log("Continua?");
        canvasPausa.SetActive(false);
        canvasEnPartida.SetActive(true);
        estaJugando = true;
    }
    public void Opciones()
    {
        LeanTween.moveLocalY(menuJuego, posInicio, tiempoAnimacion + 0.1f).setEase(animCurv).setOnComplete(() => {
            LeanTween.moveLocalY(botonNuevaPartida, posNuevaPartida, tiempoAnimacion - 0.1f).setEase(animCurv).setOnComplete(() => { //152.9541f
                LeanTween.moveLocalY(botonContinuar, posContinuar, tiempoAnimacion - 0.1f).setEase(animCurv).setOnComplete(() => {
                    LeanTween.moveLocalY(botonOpciones, posOpciones, tiempoAnimacion - 0.1f).setEase(animCurv).setOnComplete(() => { //8
                       LeanTween.moveLocalY(botonSalir, posSalir, tiempoAnimacion - 0.1f).setEase(animCurv);
                    });
                });
            });
        });

        //Para que salgan los botones de Opciones
        LeanTween.moveLocalY(barraOpciones, posicionMenu, tiempoAnimacion + 0.1f).setEase(animCurv).setOnComplete(() => {
            LeanTween.moveLocalY(botonVolver, -506, tiempoAnimacion + 0.8f).setEase(animCurv);
        });
        //Crear boton para volver, opcion menu pantalla completa y los sliders para el sonido
    }
    public void Volver()
    {
        //Poner el menu en la pantalla
        LeanTween.moveLocalY(menuJuego, posicionMenu, tiempoAnimacion).setEase(animCurv).setOnComplete(() => {
            LeanTween.moveLocalY(botonNuevaPartida, posPantallaNuevaPartida, tiempoAnimacion + 0.1f).setEase(animCurv).setOnComplete(() => { //152.9541f
                LeanTween.moveLocalY(botonContinuar, posPantallaContinuar, tiempoAnimacion + 0.1f).setEase(animCurv).setOnComplete(() => {
                    LeanTween.moveLocalY(botonOpciones, posPantallaOpciones, tiempoAnimacion + 0.1f).setEase(animCurv).setOnComplete(() => { //8
                       LeanTween.moveLocalY(botonSalir, posPantallaSalir, tiempoAnimacion + 0.1f).setEase(animCurv);
                    });
                });
            });
        });
        //Para ocultar los botones de Opciones
        LeanTween.moveLocalY(barraOpciones, posInicio, tiempoAnimacion + 0.1f).setEase(animCurv).setOnComplete(() => {
            LeanTween.moveLocalY(botonVolver, posSalir, tiempoAnimacion + 0.1f).setEase(animCurv);
        });
    }
    public void SiguienteNivel()
    { 
    
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
