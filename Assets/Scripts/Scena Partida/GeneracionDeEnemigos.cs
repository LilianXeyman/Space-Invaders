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
    //Proyectil
    [SerializeField]
    GameObject proyectilAlien;
    [SerializeField]
    float tiempoDisparo;
    [SerializeField]
    float disparo;
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
        tiempoDisparo = tiempoDisparo - Time.deltaTime;
        if (tiempoDisparo <= 0)
        {
            int ultimoElementoActivo = -1;
            int column = Random.Range(0, totalColumns);//Disparará de forma aleatoria cualquier alien de la primera fila
            for (int i = 0; i < totalRows; i++)
            {
                if (matrizObjetos[column][i] != null && matrizObjetos[column][i].activeSelf == true)
                {
                    ultimoElementoActivo = i;
                }
            }
            if (ultimoElementoActivo != -1) // Si se encontró un elemento activo
            {
                // Instanciar el proyectil desde la posición del último elemento activo
                Vector3 posicionDisparo = matrizObjetos[column][ultimoElementoActivo].transform.position;
                tiempoDisparo = disparo;
                Instantiate(proyectilAlien, posicionDisparo, Quaternion.identity);

            }

            Debug.Log("Ultimo elemento activo " + column + ", " + ultimoElementoActivo);
        }
    }
}
