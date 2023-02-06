using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorJugador : MonoBehaviour
{
    public float velocidadMovimiento; //variable velocidad del movimiento
    public float fuerzaSalto; //variable fuerza de salto
    public float escalaGravedad = 5f; //Variable gravedad caida
    public float rotacionRapida = 5f; // Varaible de rotacion rapida


    private Vector3 direccionMovimiento; //variable de  movimiento x.y.z

    public CharacterController controladorCaracter;//Accediendo al CharacterController
    public  Camera camara; //Accediendo a la camara
    public GameObject jugadorCarro;//Accediento al mismo jugador/carro


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float yValor = direccionMovimiento.y;


        //Movimiento
                //direccionMovimiento = new Vector3(Input.GetAxisRaw("Horizontal"), 0f,Input.GetAxisRaw("Vertical"));
        direccionMovimiento = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal")); //miras delanta=delante. miras atras=atras
        direccionMovimiento = direccionMovimiento * velocidadMovimiento;
        //direccionMovimiento.Normalize();
        direccionMovimiento.y = yValor;//Salto fluido
        controladorCaracter.Move(direccionMovimiento * Time.deltaTime);//Moviemiento con CharacterController
        


        //Transform de la Posición
                //transform.position = transform.position + (direccionMovimiento * Time.deltaTime * velocidadMovimiento);
        


        //Salto
        if (Input.GetButtonDown("Jump"))
        {
            direccionMovimiento.y = fuerzaSalto;
        }



        //Agregando gravedad
        direccionMovimiento.y += Physics.gravity.y * Time.deltaTime * escalaGravedad;


        //RotacionCamaraConjugador/carro
        if (Input.GetAxisRaw("Horizontal") !=0 || Input.GetAxisRaw("Vertical") !=0)
        {
            transform.rotation = Quaternion.Euler(0f,camara.transform.rotation.eulerAngles.y,0f); 
            Quaternion newRotacion = Quaternion.LookRotation(new Vector3(direccionMovimiento.x,0f,direccionMovimiento.z));   //rotacion
            jugadorCarro.transform.rotation = Quaternion.Slerp(jugadorCarro.transform.rotation, newRotacion, rotacionRapida * Time.deltaTime);//rotacion suave
        }
        
    }
}
