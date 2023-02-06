using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Muerto : MonoBehaviour
{
    public void Salir()
    {
        SceneManager.LoadScene(0);
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(1);
    }
}
