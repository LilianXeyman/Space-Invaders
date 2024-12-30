using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muertexd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Skarner") || other.CompareTag("Velkoz") || other.CompareTag("Reksai") || other.CompareTag("Khazix"))
        {
            VidasNave.Instance.canvasMuerte.SetActive(true);
            Canvas.Instance.estaJugando = false;
        }
    }
}
