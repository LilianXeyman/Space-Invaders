using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    /*[SerializeField]
    Rigidbody proyectilRb;*/
    [SerializeField]
    float velproyectil;
    [SerializeField]
    float fueraDePantalla;
    public GameObject naveElegida;
    // Start is called before the first frame update
    void Start()
    {
        //proyectilRb=GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        //proyectilRb.AddForce(new Vector3(0,10,0) * velproyectil);
        gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y + velproyectil * Time.deltaTime, gameObject.transform.position.z);
        if(gameObject.transform.position.y >= fueraDePantalla)//También se puede hacer con un collider o con una cuenta regresiva de tiempo
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Nave"))//Capaz es mejor hacerlo con arrays. De esta forma se generaran en base al tag(?)
        {
            /*Destroy(gameObject);
            naveElegida = other.gameObject;
            DontDestroyOnLoad(naveElegida);*/
        }
    }
}
