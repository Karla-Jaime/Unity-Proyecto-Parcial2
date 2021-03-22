using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Unica instancia de Inventario para todo el juego
    #region Singleton
    public static Inventory instance;
    void Awake()
    {
        if(instance != null){
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }
    #endregion

    // Evento de agregar o quitar objetos al inventario

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    // Espacio del inventario
    public int inventorySpace = 20;


    // Lista de objetos
    public List<Item> items = new List<Item>();

    // Funcion para agregar objetos, bool para poder checar si un objeto se ouede agregar antes de destruirlo desde otro script
    public bool Add(Item item){
        if(items.Count >= inventorySpace){
            Debug.Log("Not enough room");
            return false;
        }
        // Agregar objeto
        items.Add(item);
        
        // Evento
        if(onItemChangedCallback != null){
            onItemChangedCallback.Invoke();
        }
        return true;
    }
}
