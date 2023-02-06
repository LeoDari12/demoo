using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoPinchos : MonoBehaviour
{
    // Start is called before the first frame update
    public int cantidad = 10;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Daño_vida>().Restarvida(cantidad);
        }
    }
    private void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Daño_vida>().Restarvida(cantidad);
        }
    }
}
