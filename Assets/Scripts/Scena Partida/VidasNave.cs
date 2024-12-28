using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidasNave : MonoBehaviour
{
    public static VidasNave Instance;
    //Para las vidas de la nave
    [SerializeField]
    public int vidasNave;
    //Para todo lo relacionado con el canvas
    [SerializeField]
    GameObject canvasMuerte;
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
        if (vidasNave <= 0)
        {
            canvasMuerte.SetActive(true);
        }
    }
}
