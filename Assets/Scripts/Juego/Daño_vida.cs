using System;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Daño_vida : MonoBehaviour
{
   public int vida = 100;
   public bool invencible = false;
   public float tiempoInvencible = 1f;
   public float tiempoFrenado = 0.2f;

   public Slider visualizacionVida;
   
   public ControladorFinJuego panelMenuMuerto;

    void Start() 
    {
        panelMenuMuerto = GameObject.FindGameObjectWithTag("MenuMuerto").GetComponent<ControladorFinJuego>();
    }

   private void Update() 
   {
    visualizacionVida.GetComponent<Slider>().value = vida;

    if (vida <= 0)
    {
        Time.timeScale = 0f;

        if (vida <= 0)
        {
            panelMenuMuerto.menuMuerto.SetActive(true);
        }
    }
    else
    {
        Time.timeScale = 1f;
    }

   }

    public void Restarvida(int cantidad)
    {
        if (!invencible && vida > 0)
        {
            vida -= cantidad;
            StartCoroutine(Invulnerable());
            StartCoroutine(FrenarVelocidad());

        }

        IEnumerator Invulnerable()
        {
            invencible = true;
            yield return new WaitForSeconds(tiempoInvencible);
            invencible = false;

        }
        IEnumerator FrenarVelocidad()
        {
            var velocidadActual = GetComponent<ControladorJugador>().velocidadMovimiento;
            GetComponent<ControladorJugador>().velocidadMovimiento = 0;
            yield return new WaitForSeconds(tiempoFrenado);
            GetComponent<ControladorJugador>().velocidadMovimiento = velocidadActual;
        }
        
    }

    

    

}
