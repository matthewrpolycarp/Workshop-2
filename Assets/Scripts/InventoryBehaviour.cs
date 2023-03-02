using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBehaviour : MonoBehaviour
{
    public List<string> inventory;

    public void addToInventory(string itemName)
    {
        inventory.Add(itemName);
    }

    public bool hasItem(string itemName)
    {
        return inventory.Contains(itemName);
    }

    public void removeItem(string itemName)
    {
        foreach (string item in inventory)
        {
            if (item.Equals(itemName)) {
                inventory.Remove(itemName);
                break;
            }
        }
    }
}
