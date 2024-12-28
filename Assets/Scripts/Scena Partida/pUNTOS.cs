using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pUNTOS : MonoBehaviour
{
    public static pUNTOS Instance;
    //Tipos de Aliens//Poner los GameObjects
    [SerializeField]
    public GameObject velKoz;
    [SerializeField]
    public GameObject skarner;
    [SerializeField]
    public GameObject khaZix;
    [SerializeField]
    public GameObject reksai;
    //Cuenta de puntos
    /*[SerializeField]
    int puntosVelkoz;
    [SerializeField]
    int puntosSkarner;
    [SerializeField]
    int puntosKhazix;
    [SerializeField]
    int puntosReksai;*/
    [SerializeField]
    int sumaVelkoz;
    [SerializeField]
    int sumaSkarner;
    [SerializeField]
    int sumaKhazix;
    [SerializeField]
    int sumaReksai;
    [SerializeField]
    public int puntosObtenidos;
    //Para el texto en pantalla
    [SerializeField]
    TextMeshProUGUI puntosTotales;
    [SerializeField]
    TextMeshProUGUI puntosTotalesFinal;
    [SerializeField]
    TextMeshProUGUI puntosTotalesFinalGanar;
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
        //ActualizarPuntosTotales();
    }
    // Update is called once per frame
    void Update()
    {
        puntosTotalesFinal.text = puntosObtenidos.ToString("000000");
        puntosTotalesFinalGanar.text = puntosObtenidos.ToString("000000");
        MaxPuntuacion.Instance.AñadirPuntos(MaxPuntuacion.Instance.record);
    }
    /*private void ActualizarPuntosTotales()
    {
        puntosTotales.text = puntosObtenidos.ToString("0000000000");
    }*/
    public void Skarner()
    {
        if (skarner != null)
        {
            puntosObtenidos = puntosObtenidos + sumaSkarner;
        }
        puntosTotales.text = puntosObtenidos.ToString("000000");
    }
    public void Khazix()
    {
        if (khaZix != null)
        {
            puntosObtenidos = puntosObtenidos + sumaKhazix;
        }
        puntosTotales.text = puntosObtenidos.ToString("0000000");
    }
    public void Velkoz()
    {
        if (velKoz != null)
        {
            puntosObtenidos = puntosObtenidos + sumaVelkoz;
        }
        puntosTotales.text = puntosObtenidos.ToString("0000000");
    }
    public void Reksai()
    {
        if (reksai != null)
        {
            puntosObtenidos = puntosObtenidos + sumaReksai;
        }
        puntosTotales.text = puntosObtenidos.ToString("0000000");
    }
}
