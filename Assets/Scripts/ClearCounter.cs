using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class ClearCounter : BaseCounter, IKitchenObjectParent
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            // There is no KitchenObject
            if (!player.HasKitchenObject())
            {
                // Player doesn't have KitchenObject
            }
            else
            {
                // Player has KitchenObject
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
        }
        else
        {
            //There is KitchenObject
            if (!player.HasKitchenObject())
            {
                // Player doesn't have KitchenObject
                GetKitchenObject().SetKitchenObjectParent(player);
            }
            else
            {
                // Player has KitchenObject
            }
        }
    }
}
