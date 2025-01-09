using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperDisparo : MonoBehaviour
{
    //Script para hacer el super disparo
    [SerializeField]
    GameObject superDisparo;

    [SerializeField]
    float cooldownSuperDisparo;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cooldownSuperDisparo=cooldownSuperDisparo-Time.deltaTime;
        if (cooldownSuperDisparo <= 0 && Input.GetButtonDown("Fire1"))
        {
            cooldownSuperDisparo = 5f;
            Instantiate(superDisparo, transform.position, Quaternion.identity);
        }
    }
}
