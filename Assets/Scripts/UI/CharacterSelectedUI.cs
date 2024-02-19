using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectedUI : MonoBehaviour
{
    [SerializeField] Button readyButton;
    [SerializeField] Button mainMenuButton;
    [SerializeField] TextMeshProUGUI lobbyNameText;
    [SerializeField] TextMeshProUGUI lobbyCodeText;

    private void Awake()
    {
        readyButton.onClick.AddListener(() =>
        {
            CharacterSelectReady.Instance.SetPlayerReady();
        });

        mainMenuButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.Shutdown();
            Loader.Load(Loader.Scene.MainMenuScene);
        });
    }

    private void Start()
    {
        Lobby lobby =  KitchenGameLobby.Instance.GetLobby();

        lobbyNameText.text = "Lobby Name: " + lobby.Name;
        lobbyCodeText.text = "Lobby Code: " + lobby.LobbyCode;
    }
}
