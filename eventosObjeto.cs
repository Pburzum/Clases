using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class eventosObjeto : MonoBehaviour,IPointerClickHandler {


    public int posicion;
    public int id;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button.Equals(PointerEventData.InputButton.Right))
        {
            Inventario.inv.activarMenuObjeto(id,posicion,this.GetComponent<RectTransform>(),eventData.position,this.gameObject);
            // (id objeto, posicion objeto, Donde esta el objeto ,Sitio donde hemos hecho click, el GO instanciado en el que estamos)
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
