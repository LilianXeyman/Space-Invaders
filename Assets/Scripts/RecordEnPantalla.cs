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
        MaxPuntuacion.Instance.aņadirPuntosEvent += CambiarTexto;
        if (MaxPuntuacion.Instance != null) // Comprobar si MaxPuntuacion.Instance no es null
        {
            MaxPuntuacion.Instance.aņadirPuntosEvent += CambiarTexto;
        }
        else
        {
            Debug.LogWarning("MaxPuntuacion.Instance es null. No se pudo suscribir al evento aņadirPuntosEvent.");
        }
    }
    public void CambiarTexto(object sender, MaxPuntuacion.AņadirPuntosEventArgs e)
    {
        textMeshProUGUI.text = e.recordEvent.ToString();
    }
    // Update is called once per frame
    void Update()
    {

    }
}

