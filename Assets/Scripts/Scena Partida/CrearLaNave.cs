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
        else 
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        EleccionDeNava.instance.naveCreada = Instantiate(EleccionDeNava.instance.prefabsNaves[EleccionDeNava.instance.naveSeleccionada], Canvas.Instance.posicionNave, Quaternion.identity);
        EleccionDeNava.instance.naveCreada.transform.Rotate(Canvas.Instance.rotacionInicialNave);
        Menu.Instance.tiempo = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
