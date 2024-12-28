using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static MaxPuntuacion;

public class RecordEnPantalla : MonoBehaviour
{
    private TextMeshProUGUI textMeshProUGUI;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Para poder cambiar el texto del record
    void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        textMeshProUGUI.text = PlayerPrefs.GetInt("Record").ToString();//Ahora el error esta aqui :( Preguntar
        MaxPuntuacion.Instance.añadirPuntosEvent += CambiarTexto;
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

