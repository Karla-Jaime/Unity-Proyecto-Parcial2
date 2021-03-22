using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;

	Item item;	// Objeto en el inventario

	// Agregar objeto al inventario
	public void AddItem (Item newItem)
	{
		item = newItem;

		icon.sprite = item.icon;
		icon.enabled = true;
	}

	// Usar objeto
	public void UseItem ()
	{
		if (item != null)
		{
			item.Use();
		}
	}
}
