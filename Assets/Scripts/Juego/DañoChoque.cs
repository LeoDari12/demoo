using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoChoque : MonoBehaviour
{
    public int cantidad = 10;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Daño_vida>().Restarvida(cantidad);
        }
    }

    
}
