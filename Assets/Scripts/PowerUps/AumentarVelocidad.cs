using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AumentarVelocidad : MonoBehaviour, PowerUpsController
{
    [SerializeField]
    private float incrementoVelocidad = 1.5f;
    [SerializeField]
    private float duracion = 10f;
    [SerializeField]
    float fueraDePantalla;
    public void Activar(GameObject jugador)
    {
        MovimentoNave.Instance.ActivarVelocidad(incrementoVelocidad, duracion);
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
