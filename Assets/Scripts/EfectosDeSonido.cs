using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectosDeSonido : MonoBehaviour
{
    public static EfectosDeSonido Instance;
    //Sonido
    public AudioSource efectosDeSonido;//efectosDeSonido
    public AudioClip enemyShoot, playerShoot, shoot, explosion;
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
    public void Nave()
    {
        efectosDeSonido.clip = playerShoot;
        efectosDeSonido.Play();
    }
    public void Shoot()
    {
        efectosDeSonido.clip = shoot;
        efectosDeSonido.Play();
    }
    public void Explosion()
    {
        efectosDeSonido.clip = explosion;
        efectosDeSonido.Play();
    }
}
