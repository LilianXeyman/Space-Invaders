using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderGrande : MonoBehaviour
{
    /*[SerializeField]
    float tiempoPuntos;*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Skarner") || other.CompareTag("Velkoz") || other.CompareTag("Reksai") || other.CompareTag("Khazix"))
        {
            if (other.CompareTag("Skarner") /*&& tiempoPuntos <= 0*/)//En principio ya esta arreglado pero tuve que poner manualmente el tiempo para que se reestableciera que depende de la velocidad de disparo. Si esta se cambia se volveria a tener problemas
            {
                pUNTOS.Instance.Skarner();
                //tiempoPuntos = 1;
                LeanTween.rotateZ(other.gameObject, 180, 0.25f);
                LeanTween.scale(other.gameObject, Vector3.zero, 0.25f).setOnComplete(() =>
                {
                    Destroy(other.gameObject);
                });
            }
            if (other.CompareTag("Velkoz") /*&& tiempoPuntos <= 0*/)
            {
                pUNTOS.Instance.Velkoz();
                //tiempoPuntos = 1;
                LeanTween.rotateZ(other.gameObject, 180, 0.25f);
                LeanTween.scale(other.gameObject, Vector3.zero, 0.25f).setOnComplete(() =>
                {
                    Destroy(other.gameObject);
                });
            }
            if (other.CompareTag("Reksai") /*&& tiempoPuntos <= 0*/)
            {
                pUNTOS.Instance.Reksai();
                //tiempoPuntos = 1;
                LeanTween.rotateZ(other.gameObject, 180, 0.25f);
                LeanTween.scale(other.gameObject, Vector3.zero, 0.25f).setOnComplete(() =>
                {
                    Destroy(other.gameObject);
                });
            }
            if (other.CompareTag("Khazix") /*&& tiempoPuntos <= 0*/)
            {
                pUNTOS.Instance.Khazix();
                //tiempoPuntos = 1;
                LeanTween.rotateZ(other.gameObject, 180, 0.25f);
                LeanTween.scale(other.gameObject, Vector3.zero, 0.25f).setOnComplete(() =>
                {
                    Destroy(other.gameObject);
                });
            }
            EfectosDeSonido.Instance.Shoot();//Cambiar Efecto De Sonido
        }
    }
}
