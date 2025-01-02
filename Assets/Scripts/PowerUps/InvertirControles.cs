using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertirControles : MonoBehaviour, PowerUpsController
{
    [SerializeField]
    private float duracion = 5f;//El efecto del powerUp dura 5 segundos
    [SerializeField]
    float fueraDePantalla;
    public void Activar(GameObject jugador)
    {
        MovimentoNave.Instance.ActivarControlesInvertidos(duracion);
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
