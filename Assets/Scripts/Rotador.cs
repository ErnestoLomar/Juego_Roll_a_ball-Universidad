using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotador : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		
		//Rota el elemento una cantidad diferente en cada dirección y en cada intervalo de tiempo
    //Time.deltaTime es el tiempo transcurrido enc ada frame (a 60fps, valdrá 1/60s)
		transform.Rotate(new Vector3(15,30,45) * Time.deltaTime);

	}
}
