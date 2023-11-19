using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryResultUI : MonoBehaviour
{
    private const string POPUP = "Popup";

    [SerializeField] private Image backgroundImage;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Image iconImage;
    [SerializeField] private Color sussessColor;
    [SerializeField] private Color failedColor;
    [SerializeField] private Sprite sussessSprite;
    [SerializeField] private Sprite failedSprite;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        DeliveryManger.Instance.OnRecipeSuccess += DeliveryManger_OnRecipeSuccess;
        DeliveryManger.Instance.OnRecipeFailed += DeliveryManger_OnRecipeFailed;

        Hide();
    }

    private void DeliveryManger_OnRecipeFailed(object sender, System.EventArgs e)
    {
        Show();
        animator.SetTrigger(POPUP);
        backgroundImage.color = failedColor;
        messageText.text = "MESSAGE\nFAILED";
        iconImage.sprite = failedSprite;
    }

    private void DeliveryManger_OnRecipeSuccess(object sender, System.EventArgs e)
    {
        Show();
        animator.SetTrigger(POPUP);
        backgroundImage.color = sussessColor;
        messageText.text = "MESSAGE\nSUSSESS";
        iconImage.sprite = sussessSprite;
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

}
