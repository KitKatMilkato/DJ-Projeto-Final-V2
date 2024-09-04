using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorController : MonoBehaviour
{
   public List<int> keys = new List<int>();

   public void AddItem(int idItem)
   {
    keys.Add(idItem);

   }

   public void RemoveItem(int idItem)
   {
    keys.Remove(idItem);
   }

}
