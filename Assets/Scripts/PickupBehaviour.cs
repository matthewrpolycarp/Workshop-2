using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public string canBePickedUpBy = "Player";
    public string itemName = "Key";

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(canBePickedUpBy))
        {
            InventoryBehaviour inventory = collision.gameObject.GetComponent<InventoryBehaviour>();
            if (inventory != null)
            {
                inventory.addToInventory(itemName);
                this.gameObject.SetActive(false);
            }
        }
    }
}
