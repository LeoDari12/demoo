using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class CalidadController : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public int calidad;

    // Start is called before the first frame update
    void Start()
    {
        calidad = PlayerPrefs.GetInt("numeroDeCalidad", 3);  //GetInt Es para invocar el valor... 
        dropdown.value = calidad; //valor del dropdown, a calidad
        AjustarCalidad();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AjustarCalidad()
    {
        QualitySettings.SetQualityLevel(dropdown.value); //cambiar los valores de unity de calidad
        PlayerPrefs.SetInt("numeroDeCalidad", dropdown.value); //SetInt es para cambiar el valor...
        calidad = dropdown.value;
    }
}
