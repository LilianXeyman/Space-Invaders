using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MaxPuntuacion : MonoBehaviour
{
    public static MaxPuntuacion Instance;

    [SerializeField]
    private TextMeshProUGUI textoRecord;

    [SerializeField]
    private TextMeshProUGUI textoRecordEnPantalla;

    public int puntuacionActual = 0;
    public int record = 0;

    //Eventos: sirve para mantener actualizado la puntuacion maxima
    public event EventHandler<A�adirPuntosEventArgs> a�adirPuntosEvent;
    public class A�adirPuntosEventArgs : EventArgs
    {
        public int puntuacionActualEvent;
        public int recordEvent;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        record = PlayerPrefs.GetInt("Record", 0);
        ActualizarTextoRecord();
    }
    public void A�adirPuntos(int puntos)
    {
        puntuacionActual = pUNTOS.Instance.puntosObtenidos;
        if (puntuacionActual > record)
        {
            record = puntuacionActual;
            PlayerPrefs.SetInt("Record", record);
            PlayerPrefs.Save();//Te guarda siempre la puntuacion
            Debug.Log("�Nuevo Record guardado: " + record);
        }
        a�adirPuntosEvent?.Invoke(this, new A�adirPuntosEventArgs { puntuacionActualEvent = puntuacionActual, recordEvent = record });
    }
    private void ActualizarTextoRecord()
    {
        textoRecord.text = record.ToString();
        textoRecordEnPantalla.text = record.ToString();
    }
}
