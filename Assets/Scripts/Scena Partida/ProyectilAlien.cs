using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilAlien : MonoBehaviour
{
    [SerializeField]
    float velproyectil;
    [SerializeField]
    float fueraDePantalla;
    float tiempoNaveHerida;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        tiempoNaveHerida = tiempoNaveHerida - Time.deltaTime;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - velproyectil * Time.deltaTime, gameObject.transform.position.z);
        if (gameObject.transform.position.y <= fueraDePantalla)//También se puede hacer con un collider o con una cuenta regresiva de tiempo
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Nave") && tiempoNaveHerida <= 0)
        {
            VidasNave.Instance.vidasNave = VidasNave.Instance.vidasNave - 1;//Por alguna razon resta de dos en dos
            tiempoNaveHerida = 0.6f;
        }
    }
}
