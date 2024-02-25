using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class LobbyMessageUI : MonoBehaviour
{
    [SerializeField] private Button closeButton;
    [SerializeField] private TextMeshProUGUI responseMessageText;

    private void Awake()
    {
        closeButton.onClick.AddListener(Hide);
    }

    private void Start()
    {
        KitchenGameMultiplayer.Instance.OnFailedToJoinGame += KitchenGameMultiplayer_OnFailedToJoinGame;
        KitchenGameLobby.Instance.OnCreateLobbyStarted += KitchenGameLobby_OnCreateLobbyStarted;
        KitchenGameLobby.Instance.OnCreateLobbyFailed += KitchenGameLobby_OnCreateLobbyFailed;
        KitchenGameLobby.Instance.OnJoinLobbyStarted += KitchenGameLobby_OnJoinLobbyStarted;
        KitchenGameLobby.Instance.OnJoinLobbyFailed += KitchenGameLobby_OnJoinLobbyFailed;
        KitchenGameLobby.Instance.OnQuickJoinLobbyFailed += KitchenGameLobby_OnQuickJoinLobbyFailed;

        Hide();
    }

    private void KitchenGameLobby_OnQuickJoinLobbyFailed(object sender, System.EventArgs e)
    {
        ShowMessage("Failed to find Lobby");
    }

    private void KitchenGameLobby_OnJoinLobbyFailed(object sender, System.EventArgs e)
    {
        ShowMessage("Failed to join Lobby");
    }

    private void KitchenGameLobby_OnJoinLobbyStarted(object sender, System.EventArgs e)
    {
        ShowMessage("Joining Lobby...");
    }

    private void KitchenGameLobby_OnCreateLobbyFailed(object sender, System.EventArgs e)
    {
        ShowMessage("Failed to create Lobby");
    }

    private void KitchenGameLobby_OnCreateLobbyStarted(object sender, System.EventArgs e)
    {
        ShowMessage("Creating Lobby...");
    }

    private void KitchenGameMultiplayer_OnFailedToJoinGame(object sender, System.EventArgs e)
    {
        if (responseMessageText.text == "")
        {
            ShowMessage("Connection failed");
        }

        else
        {
            ShowMessage(NetworkManager.Singleton.DisconnectReason);
        }
    }

    private void ShowMessage(string message)
    {
        Show();

        responseMessageText.text = message;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        KitchenGameMultiplayer.Instance.OnFailedToJoinGame -= KitchenGameMultiplayer_OnFailedToJoinGame;
        KitchenGameLobby.Instance.OnCreateLobbyStarted -= KitchenGameLobby_OnCreateLobbyStarted;
        KitchenGameLobby.Instance.OnCreateLobbyFailed -= KitchenGameLobby_OnCreateLobbyFailed;
        KitchenGameLobby.Instance.OnJoinLobbyStarted -= KitchenGameLobby_OnJoinLobbyStarted;
        KitchenGameLobby.Instance.OnJoinLobbyFailed -= KitchenGameLobby_OnJoinLobbyFailed;
        KitchenGameLobby.Instance.OnQuickJoinLobbyFailed -= KitchenGameLobby_OnQuickJoinLobbyFailed;
    }
}
