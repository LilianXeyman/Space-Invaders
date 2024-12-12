using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoNave : MonoBehaviour
{
    // Variables para el movimiento del jugador
    [SerializeField]
    private float movimientoX;
    public float movement;

    [SerializeField]
    public float velJugador;

    [SerializeField]
    private float min;
    [SerializeField]
    private float max;

    private Rigidbody naveRb;
    void Start()
    {
        naveRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = -Input.GetAxis("Horizontal");
        Vector3 newPos = gameObject.transform.position;

        newPos.x = Mathf.Clamp(gameObject.transform.position.x + movement * velJugador * Time.deltaTime, min, max);//Clamp hace las multiplicaciones
                                                                                                                  //transform.position = new Vector3(newPosX, transform.position.y, transform.position.z);
        gameObject.transform.position = newPos;//Si pongo el Time*deltaTime va con lag. Preguntar si se puede quitar
        if (Input.GetButtonDown("Jump"))
        { 
           
        }
    }
}
