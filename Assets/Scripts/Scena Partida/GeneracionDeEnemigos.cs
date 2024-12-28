using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneracionDeEnemigos : MonoBehaviour
{
    public static GeneracionDeEnemigos Instance;
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
    //Movimiento filas
    [SerializeField]
    float velocidadMovimiento = 2.0f;
    [SerializeField]
    float desplazamientoVertical = 1.0f;
    [SerializeField]
    float limiteMinX;
    [SerializeField]
    float limiteMaxX;
    private bool moviendoALaDerecha = true; // Dirección de las filas
    //Contar los aliens (Condicion de victoria)
    public int aliensTotales;
    [SerializeField]
    GameObject canvasVictoria;
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
        aliensTotales = GameObject.FindGameObjectsWithTag("Velkoz").Length + GameObject.FindGameObjectsWithTag("Khazix").Length + GameObject.FindGameObjectsWithTag("Skarner").Length + GameObject.FindGameObjectsWithTag("Velkoz").Length;
        Debug.Log("Aliens Totales: " + aliensTotales);
    }

    // Update is called once per frame
    void Update()
    {
        if (Canvas.Instance.estaJugando == true)
        {
            tiempoDisparo = tiempoDisparo - Time.deltaTime;
            if (tiempoDisparo <= 0)
            {
                DispararProyectil();
                tiempoDisparo = disparo;
            }

            MoverFilas();
        }
        Debug.Log("Aliens Totales: " + aliensTotales);
        if (aliensTotales <= 1) //???????????
        { 
           canvasVictoria.SetActive(true); //Crear logica siguiente nivel aumentando una fila y la vel de los aliens
        }
    }
    public void AumentaNivel() //Poner que cuando se le de al boton de siguiente nivel el totalColumns o el totalRow aumente en 1
    {
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
        aliensTotales = GameObject.FindGameObjectsWithTag("Velkoz").Length + GameObject.FindGameObjectsWithTag("Khazix").Length + GameObject.FindGameObjectsWithTag("Skarner").Length + GameObject.FindGameObjectsWithTag("Velkoz").Length;
        Debug.Log(aliensTotales);
    }
    private void DispararProyectil()
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
            Instantiate(proyectilAlien, posicionDisparo, Quaternion.identity);
            Debug.Log("Ultimo elemento activo " + column + ", " + ultimoElementoActivo);
        }
        EfectosDeSonido.Instance.Enemy();
    }
    private void MoverFilas()
    {
        bool cambiarDireccion = false;
        //Con esto compruebas si la fila necesita ser cambiada de direccion
        foreach(var columna in matrizObjetos)//El foreach toma un elemento a la vez de la colección y ejecuta un bloque de código con ese elemento
        {
            foreach (var alien in columna)
            {
                if (alien != null && alien.activeSelf)
                {
                    if (moviendoALaDerecha && alien.transform.position.x >= limiteMaxX)//Si alcanza el l'imite derecho cambia de direccion
                    {
                        cambiarDireccion = true;
                    }
                    else if (!moviendoALaDerecha && alien.transform.position.x <= limiteMinX)//Cuando no se mueva hacia la derecha y alcance el limite izq cambia la direccion y el bool
                    {
                        cambiarDireccion = true;
                    }
                }
            }
        }
        //Para el movimiento hacia abajo
        if (cambiarDireccion == true)
        {
            moviendoALaDerecha = !moviendoALaDerecha;//Si antes se movia pa un lado ahora cambia la direccion
            foreach (var columna in matrizObjetos)
            {
                foreach (var alien in columna)
                {
                    if (alien != null && alien.activeSelf)
                    {
                        alien.transform.position = alien.transform.position - new Vector3(0, desplazamientoVertical, 0);//Mueve las filas hacia abajo
                    }
                }
            }
        }
        //Para el movimiento lateral
        float desplazamiento = (moviendoALaDerecha ? 1 : -1) * velocidadMovimiento * Time.deltaTime;//Si moviendoALaDerecha es true, el valor será 1 (hacia la derecha).Si es false, el valor será - 1(hacia la izquierda).Esto determina si el desplazamiento será positivo(derecha) o negativo(izquierda).//El ? Se utiliza para evaluar una condición y devolver un valor basado en el resultado de esa evaluación. Es una forma compacta de escribir un if-else.
        foreach (var columna in matrizObjetos)
        {
            foreach (var alien in columna)
            {
                if (alien != null && alien.activeSelf)
                {
                    alien.transform.position += new Vector3(desplazamiento, 0, 0);
                }
            }
        }
    }
}
