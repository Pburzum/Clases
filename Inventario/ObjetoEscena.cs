using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoEscena : MonoBehaviour {

    public int id = -1;
    public int cantidad = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (Inventario.inv.canAdd(id))
        {
            Inventario.inv.agregarObjeto(id);
            Debug.Log("Has recogido un objeto");
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager1>().setText("Has recogido un objeto");
            Destroy(gameObject);
        }
    }
}
