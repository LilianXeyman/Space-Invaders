using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectosDeSonido : MonoBehaviour
{
    public static EfectosDeSonido Instance;
    //Sonido
    public AudioSource efectosDeSonido;//efectosDeSonido
    public AudioClip enemyShoot, playerShoot, shoot;
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
    public void Enemy()
    {
        efectosDeSonido.clip = enemyShoot;
        efectosDeSonido.Play();
    }
    public void Player()
    {
        efectosDeSonido.clip = playerShoot;
        efectosDeSonido.Play();
    }
    public void Shoot()
    {
        efectosDeSonido.clip = shoot;
        efectosDeSonido.Play();
    }
}
