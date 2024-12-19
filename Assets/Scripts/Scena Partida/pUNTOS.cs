using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pUNTOS : MonoBehaviour
{
    //Tipos de Aliens//Poner los GameObjects
    [SerializeField]
    GameObject velKoz;
    [SerializeField]
    GameObject skarner;
    [SerializeField]
    GameObject khaZix;
    [SerializeField]
    GameObject reksai;
    //Cuenta de puntos
    int puntosVelkoz;
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
    // Start is called before the first frame update
    void Start()
    {
        puntosObtenidos = puntosObtenidos + puntosVelkoz + puntosSkarner + puntosKhazix + puntosReksai;
    }

    // Update is called once per frame
    void Update()
    {
        puntosTotales.text = puntosObtenidos.ToString("0000000000");
    }
    private void OnTriggerEnter(Collider other)
    {
        //Hacer que cuando el gameObject que tiene el script se desstruya te de puntos dependiendo del alien te da más o menos puntos también puedes poner los aliens segun un tipo de gameObject
        if (other ==velKoz)
        {
            puntosVelkoz = puntosVelkoz + sumaVelkoz;
        }
        if (other == skarner)
        {
            puntosSkarner=puntosSkarner + sumaSkarner;
        }
        if (other == khaZix)
        {
            puntosKhazix=puntosKhazix + sumaKhazix;
        }
        if (other == reksai)
        {
            puntosReksai=puntosReksai + sumaReksai;
        }
    }
}
