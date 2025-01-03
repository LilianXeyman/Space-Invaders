using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VidasNave : MonoBehaviour
{
    public static VidasNave Instance;
    //Para las vidas de la nave
    [SerializeField]
    public int vidasNave;
    //Para todo lo relacionado con el canvas
    [SerializeField]
    public GameObject canvasMuerte;
    [SerializeField]
    TextMeshProUGUI cuentaVidasNave;
    [SerializeField]
    TextMeshProUGUI cuentaVidasNaveMuerte;
    [SerializeField]
    TextMeshProUGUI cuentaVidasNaveVictoria;
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
    // Start is called before the first frame update
    void Start()
    {
        canvasMuerte.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        cuentaVidasNave.text = vidasNave.ToString();
        cuentaVidasNaveMuerte.text = vidasNave.ToString();
        cuentaVidasNaveVictoria.text = vidasNave.ToString();
        if (vidasNave <= 0)
        {
            canvasMuerte.SetActive(true);
            Canvas.Instance.estaJugando = false;
        }
    }
}
