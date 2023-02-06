using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

using TMPro;

public class PantallaCompletaController : MonoBehaviour
{
    public Toggle toggle;

    public TMP_Dropdown resolucionesDropDown;
    Resolution[] resoluciones; // crear arreglo de todas las resoluciones disponibles

    void Start()
    {
        if (Screen.fullScreen) //detectar si estamos en ventana completa 
        {
            toggle.isOn = true; //detecta si esta en pantalla completa... lo vuelva true...(marca la casilla)
        }
        else
        {
            toggle.isOn = false; //detecta si no esta en pantalla completa... lo vuelve false...(desmarca la casilla)
        }


        RevisarResolucion();

    }

    public void ActivarPantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta; //cambio a pantall completa cuando es true y pantalla normal cuando es false
    }

    public void RevisarResolucion()
    {
        resoluciones = Screen.resolutions; // Guarada todas las resoluciones automaticamente de nuestro PC en ese arreglo(resoluciones)
        resolucionesDropDown.ClearOptions(); //Borrar resolucion de una a pc a otra ya que son diferentes resoluciones que contiene cada una
        List<string> opciones = new List<string>(); //Lista de letras
        int resolucionActual = 0; // variables que sea cero, osea nuestra resolucion actual

        for (int i = 0; i < resoluciones.Length; i++)
        {
            string opcion = resoluciones[i].width + " x " + resoluciones[i].height;
            opciones.Add(opcion);


            if (Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width &&
                resoluciones[i].height == Screen.currentResolution.height) //Revisar si la opcion es la que hemos guardado es la que tenemos actualmente
            {
                resolucionActual = i; //verificacion 
            }

        }

        resolucionesDropDown.AddOptions(opciones);
        resolucionesDropDown.value = resolucionActual;
        resolucionesDropDown.RefreshShownValue();


        //
        resolucionesDropDown.value = PlayerPrefs.GetInt("numeroResolucion", 0);
        //
    }

    public void CambiarResolucion(int indiceResolucion)
    {
        //
        PlayerPrefs.SetInt("numeroResolucion", resolucionesDropDown.value);
        //


        Resolution resolution = resoluciones[indiceResolucion];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
