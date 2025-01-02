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
    //El sistema de puntos me funciona mal voy a probar a poner un contador
    [SerializeField]
    float tiempoPuntos;
    //Para los powerUps(array)
    [SerializeField]
    private GameObject[] powerUps;
    GameObject powerUpGenerado;
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
        tiempoPuntos = tiempoPuntos - Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("0"))
        {
            EleccionDeNava.instance.naveSeleccionada = 0;
            Menu.Instance.tiempo = true;
        }
        if (other.CompareTag("1"))
        {
            EleccionDeNava.instance.naveSeleccionada = 1;
            Menu.Instance.tiempo = true;
        }
        if (other.CompareTag("2"))
        {
            EleccionDeNava.instance.naveSeleccionada = 2;
            Menu.Instance.tiempo = true;
        }
        if (other.CompareTag("Skarner") || other.CompareTag("Velkoz") || other.CompareTag("Reksai") || other.CompareTag("Khazix"))
        {
            Destroy(gameObject);
            if (Random.value <= 0.15f)
            {
                GenerarPowerUpAleatorio();
            }
            if (other.CompareTag("Skarner") && tiempoPuntos <=0)//En principio ya esta arreglado pero tuve que poner manualmente el tiempo para que se reestableciera que depende de la velocidad de disparo. Si esta se cambia se volveria a tener problemas
            {
                    pUNTOS.Instance.Skarner();
                    tiempoPuntos = 1;
                    LeanTween.rotateZ(other.gameObject, 180, 0.25f);
                    LeanTween.scale(other.gameObject, Vector3.zero, 0.25f).setOnComplete(() =>
                    {
                        Destroy(other.gameObject);
                    });
            }
            if (other.CompareTag("Velkoz") && tiempoPuntos <= 0)
            {
                    pUNTOS.Instance.Velkoz();
                    tiempoPuntos = 1;
                    LeanTween.rotateZ(other.gameObject, 180, 0.25f);
                    LeanTween.scale(other.gameObject, Vector3.zero, 0.25f).setOnComplete(() =>
                    {
                        Destroy(other.gameObject);
                    });
            }
            if (other.CompareTag("Reksai") && tiempoPuntos <= 0)
            {
                    pUNTOS.Instance.Reksai();
                    tiempoPuntos = 1;
                    LeanTween.rotateZ(other.gameObject, 180, 0.25f);
                    LeanTween.scale(other.gameObject, Vector3.zero, 0.25f).setOnComplete(() =>
                    {
                        Destroy(other.gameObject);
                    });
            }
            if (other.CompareTag("Khazix") && tiempoPuntos <= 0)
            {
                    pUNTOS.Instance.Khazix();
                    tiempoPuntos = 1;
                    LeanTween.rotateZ(other.gameObject, 180, 0.25f);
                    LeanTween.scale(other.gameObject, Vector3.zero, 0.25f).setOnComplete(() =>
                    {
                        Destroy(other.gameObject);
                    });
            }
            EfectosDeSonido.Instance.Shoot();
        }
    }
    private void GenerarPowerUpAleatorio()
    {
        int indiceAleatorio = Random.Range(0, powerUps.Length);
        powerUpGenerado = Instantiate(powerUps[indiceAleatorio], transform.position, Quaternion.identity);
        LeanTween.rotateY(powerUpGenerado, 90, 0);
    }
}
