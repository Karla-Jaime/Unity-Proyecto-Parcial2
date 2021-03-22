using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : ScriptableObject 
{
    [SerializeField]
    public Sprite icon = null;
    
    [SerializeField]
    protected string objectName = "Mineral";
}
