using System;
using UnityEngine;

[System.Serializable]
public class Item: ISerializationCallbackReceiver
{
    public int id;
    public String nombre;
    public String casillaString;
    public double precio { get; set; }
    public Casilla casilla = Casilla.NULO;
    public String rarezaString;
    public Rareza rareza = Rareza.COMUN;
    public string rutaSprite;
    public string nombreSprite;
    public void OnAfterDeserialize()
    {
        this.rutaSprite = "Sprites/" + nombreSprite;
    }
    //Constructor
    public Item(int id, double precio, Casilla c, String nombre,Rareza rareza, string nombreSprite)
    {
        this.id = id;
        this.precio = precio;
        this.casilla = c;
        this.nombre = nombre;
        this.rareza = rareza;
        this.nombreSprite = nombreSprite;
    }

    public Item()
    {

    }

    public int Id
    {
        get { return this.id; }
        set { this.id = value; }
    }
    //Propiedades son los getter y setter de Java
    public Casilla Casilla
    {
        get { return this.casilla; }
        set { this.casilla = value; }
    }
    public double Precio
    {
        get { return this.precio; }
        set { this.precio = value; }
    }

   public void generarEnumItem()
    {
        switch(this.casillaString){
            case "cabeza":
                this.casilla = Casilla.CABEZA;
                break;
            case "pecho":
                this.casilla = Casilla.PECHO;
                break;
            case "piernas":
                this.casilla = Casilla.PIERNAS;
                break;
            case "pies":
                this.casilla = Casilla.PIES;
                break;
            case "mano_izquierda":
                this.casilla = Casilla.MANO_IZQUIERDA;
                break;
            case "mano_derecha":
                this.casilla = Casilla.MANO_DERECHA;
                break;
            case "dos_manos":
                this.casilla = Casilla.DOS_MANOS;
                break;
            case "pocion":
                break;
        }

    }

    public void generarEnumEquipo()
    {
        switch (this.rarezaString)
        {
            case "raro":
                this.rareza = Rareza.RARO;
                break;
            case "epico":
                this.rareza = Rareza.EPICO;
                break;
            case "legendario":
                this.rareza = Rareza.LEGENDARIO;
                break;
            default:
                this.rareza = Rareza.COMUN;
                break;
        }
    }

    public void OnBeforeSerialize()
    {
        
    }
}

public enum Casilla
{
    CABEZA,
    PECHO,
    PIERNAS,
    PIES,
    MANO_IZQUIERDA,
    MANO_DERECHA,
    DOS_MANOS,
    POCION,
    NULO,
}

