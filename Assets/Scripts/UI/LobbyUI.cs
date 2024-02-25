using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUI : MonoBehaviour
{
    [SerializeField] Button mainMenuButton;
    [SerializeField] Button createLobbyButton;
    [SerializeField] Button quickJoinButton;
    [SerializeField] Button joinCodeButton;
    [SerializeField] TMP_InputField joinCodeInputField;
    [SerializeField] TMP_InputField playerNameInputField;
    [SerializeField] LobbyCreateUI lobbyCreateUI;
    [SerializeField] Transform lobbyContainer;
    [SerializeField] Transform lobbyTemplate;

    private void Awake()
    {
        mainMenuButton.onClick.AddListener(() =>
        {
            KitchenGameLobby.Instance.LeaveLobby();

            Loader.Load(Loader.Scene.MainMenuScene);
        });

        createLobbyButton.onClick.AddListener(() =>
        {
            lobbyCreateUI.Show();
        });

        quickJoinButton.onClick.AddListener(() =>
        {
            KitchenGameLobby.Instance.QuickJoin();
        });

        joinCodeButton.onClick.AddListener(() =>
        {
            KitchenGameLobby.Instance.JoinWithCode(joinCodeInputField.text);
        });

        lobbyTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        playerNameInputField.text = KitchenGameMultiplayer.Instance.GetPlayerName();
        playerNameInputField.onValueChanged.AddListener((string newPlayerName) => {
            KitchenGameMultiplayer.Instance.SetPlayerName(newPlayerName);
        });

        KitchenGameLobby.Instance.OnListOfLobbiesChanged += KitchenGameLobby_OnListOfLobbiesChanged;
        UpdateListOfLobbies(new List<Lobby>());
    }

    private void KitchenGameLobby_OnListOfLobbiesChanged(object sender, KitchenGameLobby.OnListOfLobbiesChangedEventArgs e)
    {
        UpdateListOfLobbies(e.listOfLobbies);
    }

    private void UpdateListOfLobbies(List<Lobby> listOfLobbies)
    {
        foreach (Transform child in lobbyContainer)
        {
            if (child == lobbyTemplate) continue;
            Destroy(child.gameObject);
        }

        foreach (Lobby lobby in listOfLobbies)
        {
            Transform lobbyTransform = Instantiate(lobbyTemplate, lobbyContainer);
            lobbyTransform.gameObject.SetActive(true);
            lobbyTransform.GetComponent<LobbyListSingleUI>().SetLobby(lobby);
        }
    }

    private void OnDestroy()
    {
        KitchenGameLobby.Instance.OnListOfLobbiesChanged -= KitchenGameLobby_OnListOfLobbiesChanged;
    }
}
