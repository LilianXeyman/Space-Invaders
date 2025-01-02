using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoRapido : MonoBehaviour, PowerUpsController
{
    [SerializeField]
    private float nuevoDisparo=0.2f;
    [SerializeField]
    private float duracion = 4f;
    [SerializeField]
    float fueraDePantalla;
    public void Activar(GameObject jugador)
    {
        MovimentoNave.Instance.ActivarDisparoRapido(nuevoDisparo, duracion);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Nave"))
        {
            Activar(other.gameObject);
        }
    }
    private void Update()
    {
        if (gameObject.transform.position.y <= fueraDePantalla)//También se puede hacer con un collider o con una cuenta regresiva de tiempo
        {
            Destroy(gameObject);
        }
    }
}
