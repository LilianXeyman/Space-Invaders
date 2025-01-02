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
    [SerializeField]
    float disparoOriginal=0.6f;
    //Variables para los powerUps
    private bool controlesInvertidos= false;
    private float tiempoPowerUpVelocidad=0;
    private float tiempoPowerUpDisparo = 0;
    private float modificadorVelocidad=1;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        /*else
        {
            Destroy(this);
        }*/
    }
    void Start()
    {
        naveRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        tiempoDisparo = tiempoDisparo - Time.deltaTime;
        if (Menu.Instance.tiempo == true || Canvas.Instance.estaJugando == true)
        {
           //Movimiento nave
            movement = -Input.GetAxis("Horizontal");
            if(controlesInvertidos==true)
            {
                movement = -movement;
            }
            Vector3 newPos = gameObject.transform.position;
            newPos.x = Mathf.Clamp(gameObject.transform.position.x + movement * velJugador *modificadorVelocidad* Time.deltaTime, min, max);//Clamp hace las multiplicaciones                                                                                                         
            gameObject.transform.position = newPos;
           //Disparo nave
            if (Input.GetButton("Jump"))// Para hacerlo mientras se mantiene pulsado habría que ponerle un timer al proyectil
            {
                if (tiempoDisparo <= 0)
                {
                    CrearProyectil();
                }
            }
        }
        //Para los powerUps
        //Tiempo de duracion del PowerUp
        if (tiempoPowerUpVelocidad > 0)
        { 
            tiempoPowerUpVelocidad=tiempoPowerUpVelocidad-Time.deltaTime;
            if (tiempoPowerUpVelocidad <= 0)
            {
                modificadorVelocidad = 1;
            }
        }
        if (tiempoPowerUpDisparo > 0)
        { 
            tiempoPowerUpDisparo=tiempoPowerUpDisparo-Time.deltaTime;
            if (tiempoPowerUpDisparo <= 0)
            {
                disparo = disparoOriginal;
            }
        }
    }
    private void CrearProyectil()
    { 
        tiempoDisparo = disparo;
        GameObject proyectilCreado = Instantiate(proyectil, transform.position, Quaternion.identity);
        EfectosDeSonido.Instance.Nave();
    }
    public void ActivarControlesInvertidos(float duracion)
    { 
        controlesInvertidos = true;
        StartCoroutine(DesactivarControlesInvertidos(duracion));
    }
    private IEnumerator DesactivarControlesInvertidos(float duracion)
    {
        yield return new WaitForSeconds(duracion);
        controlesInvertidos = false;
    }
    public void ActivarVelocidad(float incremento, float duracion)
    {
        modificadorVelocidad = incremento;
        tiempoPowerUpVelocidad = duracion;
    }

    public void ActivarDisparoRapido(float nuevoDisparo, float duracion)
    {
        disparo = nuevoDisparo;
        tiempoPowerUpDisparo = duracion;
    }
}
