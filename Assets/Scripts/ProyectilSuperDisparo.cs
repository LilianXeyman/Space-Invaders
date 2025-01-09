using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilSuperDisparo : MonoBehaviour
{
    public static ProyectilSuperDisparo Instance;
    [SerializeField]
    float fueraDePantalla;
    [SerializeField]
    float velproyectil;

    [SerializeField]
    float tiempoPuntos;

    [SerializeField]
    GameObject colliderGrande;
    // Start is called before the first frame update
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
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + velproyectil * Time.deltaTime, gameObject.transform.position.z);
        if (gameObject.transform.position.y >= fueraDePantalla)//También se puede hacer con un collider o con una cuenta regresiva de tiempo
        {
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Skarner") || other.CompareTag("Velkoz") || other.CompareTag("Reksai") || other.CompareTag("Khazix"))
        {
            Destroy(gameObject);
            if (other.CompareTag("Skarner") && tiempoPuntos <= 0)//En principio ya esta arreglado pero tuve que poner manualmente el tiempo para que se reestableciera que depende de la velocidad de disparo. Si esta se cambia se volveria a tener problemas
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
        Instantiate(colliderGrande, transform.position, Quaternion.identity);
    }
}
