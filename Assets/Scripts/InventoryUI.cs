using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    Inventory inventory;	// Our current inventory

    InventorySlot[] slots;
	void Start ()
	{
		inventory = Inventory.instance;
		inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
	}
    
    void Update() {
        /*
            Activar y desactivar inventario
        if ( Boton/tecla para el inventario ){
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
        */
        
    }

    void UpdateUI() {
        for(int i=0; i < slots.Length; i++){
            if(i < inventory.items.Count){
                slots[i].AddItem(inventory.items[i]);
            }
            else{
                slots[i].ClearSlot();
            }
        }
    }
}
