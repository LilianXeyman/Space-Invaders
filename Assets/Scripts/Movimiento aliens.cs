using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientoaliens : MonoBehaviour
{
    // Script para el movimiento de los aliens. Se pondrán dos condiciones. Cuando colisione con algo que cambie de direccion y que se reestablezca un tiempo. Este tiempo les permite cambiar nuevamente de dirección siempre y cuando el tiempo sea menor al puesto.
    //Lo voy a hacer por booleanos.
    [SerializeField]
    float tiempoCambioChoque;
    [SerializeField]
    float tiempoReestablecido;
    bool movIz;
    //Para el movimiento
    [SerializeField]
    private float movimientoX;
    public float movement;

    [SerializeField]
    public float velAlien;

    [SerializeField]
    private float min;
    [SerializeField]
    private float max;

    // Para el movimiento hacia abajo
    [SerializeField]
    private float intervaloMovimientoVertical; // Intervalo de tiempo para moverse hacia abajo.
    private float tiempoMovimientoVertical; // Contador para el movimiento vertical.
    [SerializeField]
    private float desplazamientoVertical; // Distancia que se moverán hacia abajo.

    void Start()
    {
        movIz = false;
        tiempoCambioChoque = tiempoReestablecido;
        tiempoMovimientoVertical = intervaloMovimientoVertical;
    }

    // Update is called once per frame
    void Update()
    {
        tiempoCambioChoque = tiempoCambioChoque-Time.deltaTime;
        if (movIz == true)
        {
            MovimientoDr();
        }
        else
        {
            MovimientoIz();
        }

        tiempoMovimientoVertical = tiempoMovimientoVertical - Time.deltaTime;
        if(tiempoMovimientoVertical<=0)
        {

            MoverHaciaAbajo();
            tiempoMovimientoVertical = intervaloMovimientoVertical;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (tiempoCambioChoque <= 0)
        {
            movIz = !movIz;
            tiempoCambioChoque = tiempoReestablecido;
        }

    }
    public void MovimientoDr()
    {
        Vector3 nuevaPos = transform.position;
        nuevaPos.x += velAlien * Time.deltaTime;
        nuevaPos.x = Mathf.Clamp(nuevaPos.x,min, max); // Restringir a los límites.
        transform.position = nuevaPos;
    }
    public void MovimientoIz()
    {
        Vector3 nuevaPos = transform.position;
        nuevaPos.x -= velAlien * Time.deltaTime;
        nuevaPos.x = Mathf.Clamp(nuevaPos.x, min, max); // Restringir a los límites.
        transform.position = nuevaPos;
    }
    public void MoverHaciaAbajo()
    {
        Vector3 nuevaPos = transform.position;
        nuevaPos.y -= desplazamientoVertical;
        transform.position = nuevaPos;
    }
}
