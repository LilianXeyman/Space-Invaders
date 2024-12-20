using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EleccionDeNava : MonoBehaviour
{
    public static EleccionDeNava instance;
    public int naveSeleccionada;
    
    [SerializeField]
    public GameObject[] prefabsNaves;

    public GameObject naveCreada;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
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
        
    }
    /*public void CrearNave()//Crear un nuevo script para la nueva escena
    {
        naveCreada = Instantiate(prefabsNaves[naveSeleccionada], Menu.Instance.posicionNave, Quaternion.identity);
        naveCreada.transform.Rotate(Menu.Instance.rotacionInicialNave);

    }*/
}
