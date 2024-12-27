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
    int puntosVelkoz;
    [SerializeField]
    int puntosSkarner;
    int puntosKhazix;
    int puntosReksai;
    [SerializeField]
    int sumaVelkoz;
    [SerializeField]
    int sumaSkarner;
    [SerializeField]
    int sumaKhazix;
    [SerializeField]
    int sumaReksai;
    [SerializeField]
    int puntosObtenidos;
    //Para el texto en pantalla
    [SerializeField]
    TextMeshProUGUI puntosTotales;
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
        ActualizarPuntosTotales();
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void ActualizarPuntosTotales()
    {
        puntosObtenidos = puntosVelkoz + puntosSkarner + puntosKhazix + puntosReksai;
        puntosTotales.text = puntosObtenidos.ToString("0000000000");
    }

    public void Skarner()
    {
        if (skarner != null)
        {
            puntosSkarner += sumaSkarner;
            //Destroy(skarner); // Destruir el objeto Skarner
        }
        ActualizarPuntosTotales();
    }
    public void Khazix()
    {
        if (khaZix != null)
        {
            puntosKhazix += sumaKhazix;
            //Destroy(skarner); // Destruir el objeto Skarner
        }
        ActualizarPuntosTotales();
    }
    public void Velkoz()
    {
        if (velKoz != null)
        {
            puntosVelkoz += sumaVelkoz;
            //Destroy(skarner); // Destruir el objeto Skarner
        }
        ActualizarPuntosTotales();
    }
    public void Reksai()
    {
        if (reksai != null)
        {
            puntosReksai += sumaReksai;
            //Destroy(skarner); // Destruir el objeto Skarner
        }
        ActualizarPuntosTotales();
    }
    /*private void OnTriggerEnter(Collider other)
    {
        // Sumar puntos según el alien que se haya colisionado
        if (other.CompareTag("Alien"))
        {
            if (other.gameObject == velKoz)
            {
                puntosVelkoz += sumaVelkoz;
                Destroy(other.gameObject);
            }
            else if (other.gameObject == skarner)
            {
                Skarner();
            }
            else if (other.gameObject == khaZix)
            {
                puntosKhazix += sumaKhazix;
                Destroy(other.gameObject);
            }
            else if (other.gameObject == reksai)
            {
                puntosReksai += sumaReksai;
                Destroy(other.gameObject);
            }

            // Actualizar puntos en pantalla
            ActualizarPuntosTotales();
        }
    }*/
}
