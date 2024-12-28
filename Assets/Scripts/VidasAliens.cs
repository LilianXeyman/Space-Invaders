using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VidasAliens : MonoBehaviour
{
    public static VidasAliens Instance;
    //Para las vidas de los aliens
    [SerializeField]
    public int vidas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Vidas()
    {
        vidas = vidas - 1;
    }
}
