using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elements : MonoBehaviour
{
    public enum Element
    {
        Fire,
        Grass,
        Water,
        Normal,
        Spirit
    }

    // Usar el enum como tipo de la propiedad
    public Element typeElemento;

    // Si necesitas un string para otras partes del código
    public string typeElementoString
    {
        get { return typeElemento.ToString(); }
    }
}
