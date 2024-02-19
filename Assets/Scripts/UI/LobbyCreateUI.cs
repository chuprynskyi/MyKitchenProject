using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyCreateUI : MonoBehaviour
{
    [SerializeField] private Button closeButton;
    [SerializeField] private Button createPrivateButton;
    [SerializeField] private Button createPublicButton;
    [SerializeField] private TMP_InputField lobbyNameInputField;

    private void Awake()
    {
        closeButton.onClick.AddListener((() =>
        {
            Hide();
        }));

        createPrivateButton.onClick.AddListener((() =>
        {
            KitchenGameLobby.Instance.CreateLobby(lobbyNameInputField.text, false);
        }));

        createPublicButton.onClick.AddListener((() =>
        {
            KitchenGameLobby.Instance.CreateLobby(lobbyNameInputField.text, true);
        }));
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
