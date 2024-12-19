using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearLaNave : MonoBehaviour
{
    public static CrearLaNave instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        EleccionDeNava.instance.naveCreada = Instantiate(EleccionDeNava.instance.prefabsNaves[EleccionDeNava.instance.naveSeleccionada], Menu.Instance.posicionNave, Quaternion.identity);
        EleccionDeNava.instance.naveCreada.transform.Rotate(Menu.Instance.rotacionInicialNave);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
