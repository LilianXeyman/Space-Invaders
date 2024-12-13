using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoNave : MonoBehaviour
{
    public static MovimentoNave Instance;
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
    //Para los disparos
    [SerializeField]
    GameObject proyectil;
    [SerializeField]
    float tiempoDisparo;
    [SerializeField]
    float disparo;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void Start()
    {
        naveRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        tiempoDisparo = tiempoDisparo - Time.deltaTime;
        if (Menu.Instance.tiempo == true)
        {
            movement = -Input.GetAxis("Horizontal");
            Vector3 newPos = gameObject.transform.position;

            newPos.x = Mathf.Clamp(gameObject.transform.position.x + movement * velJugador * Time.deltaTime, min, max);//Clamp hace las multiplicaciones
                                                                                                                       //transform.position = new Vector3(newPosX, transform.position.y, transform.position.z);
            gameObject.transform.position = newPos;//Si pongo el Time*deltaTime va con lag. Preguntar si se puede quitar
            if (Input.GetButton("Jump"))// Para hacerlo mientras se mantiene pulsado habría que ponerle un timer al proyectil
            {
                if (tiempoDisparo <= 0)
                {
                    CrearProyectil();
                }
            }
        }
    }
    private void CrearProyectil()
    { 
        tiempoDisparo = disparo;
        GameObject proyectilCreado = Instantiate(proyectil, transform.position, Quaternion.identity);
    }
}
