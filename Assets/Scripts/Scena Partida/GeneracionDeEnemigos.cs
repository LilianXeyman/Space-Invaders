using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GeneracionDeEnemigos : MonoBehaviour
{
    public static GeneracionDeEnemigos Instance;
    //Lista de objetos para los aliens
    [SerializeField]
    public int totalColumns = 5;
    [SerializeField]
    int totalRows = 4;
    [SerializeField]
    public float initialPosX;
    [SerializeField]
    public float initialPosY;
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
    public float velocidadMovimiento = 2.0f;
    [SerializeField]
    float desplazamientoVertical = 1.0f;
    [SerializeField]
    float limiteMinX;
    [SerializeField]
    float limiteMaxX;
    [SerializeField]
    float limiteInferior;
    private bool moviendoALaDerecha = true; // Dirección de las filas
    //Contar los aliens (Condicion de victoria)
    public int aliensTotales;
    [SerializeField]
    public GameObject canvasVictoria;
    //Para saber el nivel en el que estamos
    [SerializeField]
    public int nivel;
    [SerializeField]
    public TextMeshProUGUI numeroNivel;

    private int aliensIniciales;
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
        CrearNivel();
        aliensIniciales = GameObject.FindGameObjectsWithTag("Velkoz").Length + GameObject.FindGameObjectsWithTag("Khazix").Length + GameObject.FindGameObjectsWithTag("Skarner").Length + GameObject.FindGameObjectsWithTag("Reksai").Length;
    }
    //Funcion para llamar al empezar un nuevo nivel
    private void CrearNivel()
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
        aliensTotales = GameObject.FindGameObjectsWithTag("Velkoz").Length + GameObject.FindGameObjectsWithTag("Khazix").Length + GameObject.FindGameObjectsWithTag("Skarner").Length + GameObject.FindGameObjectsWithTag("Reksai").Length;
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
                if (aliensTotales >= aliensIniciales-aliensIniciales/2)
                {
                    tiempoDisparo = disparo;
                }
                else
                {
                    tiempoDisparo = disparo - 0.2f;
                }
            }
            MoverFilas();
        }
        if (aliensTotales <= 0)
        { 
           canvasVictoria.SetActive(true);
        }
        aliensTotales = GameObject.FindGameObjectsWithTag("Velkoz").Length + GameObject.FindGameObjectsWithTag("Khazix").Length + GameObject.FindGameObjectsWithTag("Skarner").Length + GameObject.FindGameObjectsWithTag("Reksai").Length;
        Debug.Log("Aliens Totales: " + aliensTotales);
    }
    public void AumentaNivel() //Poner que cuando se le de al boton de siguiente nivel el totalColumns o el totalRow aumente en 1
    {
        nivel = nivel + 1;
        numeroNivel.text = "Nivel " + nivel.ToString();
        velocidadMovimiento = velocidadMovimiento + 0.5f;
        totalColumns--;
        // Vaciar la lista de la matriz
        matrizObjetos.Clear(); 
        // Regenerar todas las columnas
        for (int i = 0; i < totalColumns; i++)
        {
            matrizObjetos.Add(new List<GameObject>());
            for (int j = 0; j < totalRows; j++)
            {
                Vector3 position = new Vector3(initialPosX, initialPosY, 0.0f);
                position.x = position.x + i * (spaceBetweenElementsX + 3);
                position.y = position.y - j * spaceBetweenElementsY;
                position.z = position.z + distanciaInicio;
                GameObject alien = Instantiate(aliens[j], position, Quaternion.identity); // Crear los aliens
                alien.name = "Alien(" + i.ToString() + "," + j.ToString() + ")";
                matrizObjetos[i].Add(alien);
            }
        }
        aliensTotales = GameObject.FindGameObjectsWithTag("Velkoz").Length + GameObject.FindGameObjectsWithTag("Khazix").Length + GameObject.FindGameObjectsWithTag("Skarner").Length + GameObject.FindGameObjectsWithTag("Reksai").Length;
        Debug.Log("Aliens Totales: " + aliensTotales);
    }
    private void DispararProyectil()//Mirar este codigo otra vez con calma
    {
        List<int> columnasConAliensActivos = new List<int>();

        // Identificar columnas con al menos un alien activo
        for (int i = 0; i < totalColumns; i++)
        {
            for (int j = 0; j < totalRows; j++)
            {
                if (matrizObjetos[i][j] != null && matrizObjetos[i][j].activeSelf)
                {
                    columnasConAliensActivos.Add(i);
                    break; // No es necesario revisar más filas en esta columna
                }
            }
        }

        // Si no hay columnas con aliens activos, no disparar
        if (columnasConAliensActivos.Count == 0)
        {
            Debug.Log("No hay aliens activos para disparar.");
            return;
        }

        // Elegir una columna aleatoria de las que tienen aliens activos
        int columnaElegida = columnasConAliensActivos[Random.Range(0, columnasConAliensActivos.Count)];
        int ultimoElementoActivo = -1;

        // Buscar el último alien activo en la columna elegida
        for (int i = 0; i < totalRows; i++)
        {
            if (matrizObjetos[columnaElegida][i] != null && matrizObjetos[columnaElegida][i].activeSelf)
            {
                ultimoElementoActivo = i;
            }
        }

        // Disparar si se encontró un alien activo
        if (ultimoElementoActivo != -1)
        {
            Vector3 posicionDisparo = matrizObjetos[columnaElegida][ultimoElementoActivo].transform.position;
            Instantiate(proyectilAlien, posicionDisparo, Quaternion.identity);
            Debug.Log("Proyectil disparado desde la columna " + columnaElegida + ", fila " + ultimoElementoActivo);
            EfectosDeSonido.Instance.Enemy();
        }
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
                    if (moviendoALaDerecha && alien.transform.position.x >= limiteMaxX)//Si alcanza el limite derecho cambia de direccion
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
