using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [Serializable]
    private struct KitchenObject_GameObject
    {
        public GameObject gameObject;
        public KitchenObjectSO kitchenObjectSO;
    }

    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [SerializeField] private List<KitchenObject_GameObject> kitchenObjectGameObjectsList;

    private void Start()
    {
        plateKitchenObject.OnIngredientAdd += PlateKitchenObject_OnIngredientAdd;

        foreach (KitchenObject_GameObject kitchenObjectGameObject in kitchenObjectGameObjectsList)
        {
            kitchenObjectGameObject.gameObject.SetActive(false);
        }
    }

    private void PlateKitchenObject_OnIngredientAdd(object sender, PlateKitchenObject.OnIngredientAddEventArgs e)
    {
        foreach (KitchenObject_GameObject kitchenObjectGameObject in kitchenObjectGameObjectsList)
        {
            if (kitchenObjectGameObject.kitchenObjectSO == e.kitchenObjectSO)
            {
                kitchenObjectGameObject.gameObject.SetActive(true);
            }
        }
    }
}
