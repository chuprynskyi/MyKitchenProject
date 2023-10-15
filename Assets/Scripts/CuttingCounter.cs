using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO cutKitchenObjectSO;

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

    public override void InteractAlternate(Player player)
    {
        if (HasKitchenObject())
        {
            //There is a KitchenObject here
            GetKitchenObject().DestroySelf();

            Transform kitchenObjectTransform = Instantiate(cutKitchenObjectSO.prefab);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        }
    }
}
