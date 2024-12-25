using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidasNave : MonoBehaviour
{
    public static VidasNave Instance;
    //Para las vidas de la nave
    [SerializeField]
    public int vidasNave;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vidasNave <= 0)
        {
            Debug.Log("Sin vidas");
        }
    }
}
