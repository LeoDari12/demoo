using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estrella : MonoBehaviour
{
    public GameObject ObjectoPuntos;
    public float puntosQueDa;
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag=="Player")
        {
            ObjectoPuntos.GetComponent<Puntos>().puntos += puntosQueDa;
            Destroy(gameObject);
        }
    }
}
