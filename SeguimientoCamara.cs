using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimientoCamara : MonoBehaviour {

    GameObject jugador;
	// Use this for initialization
	void Start () {
        //Asociamos ,nada mas crear el objeto(comenzar la escena), un gameobject al que tenga la etiqueta de "player"
        jugador = GameObject.FindGameObjectWithTag("Player");
       
	}
	
	// Sobreescribimos el evento LateUpdate para que la ejecución del código sea en el ultimo frame de movimiento.
	void LateUpdate () {
        //El transform de la camara se acopla con la posición del transform del jugador, haciendo asi que siempre este fijado en el.
        transform.position = jugador.transform.position;
	}
}
