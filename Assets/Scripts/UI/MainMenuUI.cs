using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] Button multiplayerPlayButton;
    [SerializeField] Button singleplayerPlayButton;
    [SerializeField] Button quitButton;

    private void Awake()
    {
        multiplayerPlayButton.onClick.AddListener(() =>
        {
            KitchenGameMultiplayer.isPlayMultiplayer = true;
            Loader.Load(Loader.Scene.LobbyScene);
        });

        singleplayerPlayButton.onClick.AddListener(() =>
        {
            KitchenGameMultiplayer.isPlayMultiplayer = false;
            Loader.Load(Loader.Scene.LobbyScene);
        });
        quitButton.onClick.AddListener(() =>
        {
#if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        });

        Time.timeScale = 1.0f;
    }
}
