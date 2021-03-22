using UnityEngine;

[CreateAssetMenu(fileName = "Nuevo objeto", menuName = "Inventory/Item ")]
public class Item : ScriptableObject
{
    new public string name = "New item";
    public Sprite icon = null;
    public string description = "Item Description";

    public virtual void Use(){
        Debug.Log("Using " + name);
    }
}
