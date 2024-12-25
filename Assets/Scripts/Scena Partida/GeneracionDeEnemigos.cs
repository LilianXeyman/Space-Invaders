using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneracionDeEnemigos : MonoBehaviour
{
    //Lista de objetos para los aliens
    [SerializeField]
    int totalColumns = 5;
    [SerializeField]
    int totalRows = 4;
    [SerializeField]
    float initialPosX;
    [SerializeField]
    float initialPosY;
    [SerializeField]
    float spaceBetweenElementsX;
    [SerializeField]
    float spaceBetweenElementsY;
    [SerializeField]
    float distanciaInicio;
    [SerializeField]
    GameObject[] aliens;
    List<List<GameObject>> matrizObjetos = new List<List<GameObject>>();
    // Start is called before the first frame update
    void Start()
    {
        //Se hara un bucle para que se generen las filas y las columnas
        for (int i = 0; i < totalColumns; i++)
        { 
            matrizObjetos.Add(new List<GameObject>());
            for (int j = 0; j < totalRows; j++)
            {
                Vector3 position = new Vector3(initialPosX, initialPosY, 0.0f);
                position.x = position.x + i * spaceBetweenElementsX;
                position.y = position.y - j * spaceBetweenElementsY;
                position.z = position.z + distanciaInicio;
                GameObject alien = Instantiate(aliens[j], position, Quaternion.identity);//Son 4 filas y 4 tipos de aliens
                alien.name = "Alien(" + i.ToString() + "," + j.ToString() + ")";
                matrizObjetos[i].Add(alien);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*  int ultimoElementoActivo = -1;
            for (int i = 0; i < totalRow;i++)
            {
                if (matrizObjetos[randX][i].activeSelf == true)
                {
                    ultimoElementoActivo = i;
                }
            }
            Debug.Log("Ultimo elemento activo " + randX + ", " + ultimoElementoActivo);*/
    }
}
