using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static MaxPuntuacion;

public class RecordEnPantalla : MonoBehaviour
{
    private TextMeshProUGUI textMeshProUGUI;

    // Para poder cambiar el texto del record
    void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        //textMeshProUGUI.text = PlayerPrefs.GetInt("Record").ToString();
        MaxPuntuacion.Instance.añadirPuntosEvent += CambiarTexto;
        if (MaxPuntuacion.Instance != null) // Comprobar si MaxPuntuacion.Instance no es null
        {
            MaxPuntuacion.Instance.añadirPuntosEvent += CambiarTexto;
        }
        else
        {
            Debug.LogWarning("MaxPuntuacion.Instance es null. No se pudo suscribir al evento añadirPuntosEvent.");
        }
    }
    public void CambiarTexto(object sender, MaxPuntuacion.AñadirPuntosEventArgs e)
    {
        textMeshProUGUI.text = e.recordEvent.ToString();
    }
    // Update is called once per frame
    void Update()
    {

    }
}

