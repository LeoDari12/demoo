using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI; // Habilita las opcciones de la interfaz de usuario

public class BrilloController : MonoBehaviour
{
    public Slider slider; //Variable publica de slider 
    public float sliderValue; // Variable float, que seria el valor del slider
    public Image panelBrillo; // Variable imagen que seria el panel brillo

    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("brillo", 0.5f); // slider value tendra un valor ya sea en brillo o si no sera 0.4f

        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, slider.value); 
    }

    //Update is called once per frame
    void Update()
    {

    }

    public void ChangeSlider(float valor) //cambiar el valor del slider
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("brillo", sliderValue); // aqui se guarda el valor nuevo del slider en "brillo"
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, slider.value); // cada que se mueva el valor de slider tambien el alfa de panelbrillo se movera
    }
}
