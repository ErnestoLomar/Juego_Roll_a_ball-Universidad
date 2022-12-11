using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Las 3 líneas anteriores hacen referencia al conjunto de librerías que usará nuestro script

//Declaro el nombre de la clase, que "hereda" todo de una clase superior, llamada MonoBehaviour
//Ámbito: pública se puede usar en cualquier lugar del proyecto, referenciándola adecuadamente
//Tipo: Class
//Nombre: JugadorController
//Herencia: MonoBehaviour
public class JugadorController : MonoBehaviour {

	//Declaro una variable de tipo RigidBody que luego asociaremos a nuestro Jugador
	//Ámbito: privada (solo se puede usar en este script) y no sería necesario ponerlo
	//Tipo: Rigidbody
	//Nombre: rb
	private Rigidbody rb;
    public float velocidad;
    private int contador = 0;
    public Text textoContador, textoGanar, textoTiempo;
    public float timer = 20;
    public GameObject jugadorChido;

	// Use this for initialization
	void Start () {
		
		//Capturo esa variable al iniciar el juego
		rb = GetComponent<Rigidbody>();
        setTextoContador();
        textoGanar.text = "";
	}
	
	// Para que se sincronice con los frames de física del motor
	void FixedUpdate () {
		
		//Estas variables nos capturan el movimiento en horizontal y vertical de nuestro teclado
		float movimientoH = Input.GetAxis("Horizontal");
		float movimientoV = Input.GetAxis("Vertical");
        
        
		//Un vector 3 es un trío de posiciones en el espacio XYZ, en este caso el que corresponde al movimiento
		Vector3 movimiento = new Vector3(movimientoH, 0.0f, movimientoV);

		//Asigno ese movimiento o desplazamiento a mi RigidBody
        rb.AddForce(movimiento * velocidad);
        timer -= Time.deltaTime;
        textoTiempo.text = "Cronometro: "+timer.ToString("f0");
        if (timer <= 0){
            jugadorChido.SetActive(false);
            textoGanar.text = "Perdiste, se acabo el tiempo.";
        }
	}

    //Se ejecuta al entrar a un objeto con la opción isTrigger seleccionada
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("Coleccionable"))
        {
        //Desactivo el objeto
        other.gameObject.SetActive (false);
        //Incremento el contador en uno (también se peude hacer como contador++)
        contador = contador + 1;
        //Muestro en la consola de depuración el número de coleccionables recogidos
        //Debug.Log("Coleccionables recogidos: " + contador);
        setTextoContador();
        }
        if (other.gameObject.CompareTag("Pared")){
            jugadorChido.SetActive(false);
            textoGanar.text = "Perdiste, tocaste pared.";
        }
    }
    void setTextoContador()
    {
        //Para encadenar un texto con una variable, el texto va entre comillas y la variable se encadena con el signo + 
        textoContador.text = "Contador: " + contador.ToString();
        
        //Para comparar si dos valores son iguales, utilizamos ==
        if (contador == 12){
            textoGanar.text = "¡Ganaste!";
            textoGanar.color = Color.green;
            jugadorChido.SetActive(false);
        }
    }
}