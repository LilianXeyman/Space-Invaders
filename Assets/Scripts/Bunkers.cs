using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunkers : MonoBehaviour
{
    //Script para controlar los bunkers y su regeneracion 
    //Para controlar el tiempo
    [SerializeField]
    float tiempo;
    [SerializeField]
    public float tiempoRecallBunker;
    [SerializeField]
    bool activo;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        activo = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!activo)
        {
            tiempo = tiempo - Time.deltaTime;
            if (tiempo <= 0)
            {
                Reactivar();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (activo == true)
        {
            if (other.CompareTag("Proyectil"))
            {
                Desactivar(tiempoRecallBunker);
                Destroy(other.gameObject);
            }
            if (other.CompareTag("Skarner") || other.CompareTag("Velkoz") || other.CompareTag("Reksai") || other.CompareTag("Khazix"))
            {
                Desactivar(tiempoRecallBunker * 10);
                Destroy(other.gameObject);
            }
        }
    }
    private void Desactivar(float nuevoTiempo)
    {
        activo = false;
        tiempo = nuevoTiempo;
        SetVisible(false);
        Debug.Log($"Bunker desactivado por {nuevoTiempo} segundos");
    }
    private void Reactivar()
    {
        activo = true;
        SetVisible(true);
        Debug.Log("Bunker reactivado");
    }
    private void SetVisible(bool visible)
    { 
        Renderer renderer=GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = visible;
            }
    }
}
