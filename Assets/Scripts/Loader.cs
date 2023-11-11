using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    public enum Scene
    {
        MainMenuScene,
        LoaderScene,
        GameScene
    }

    private static Scene targetScene;

    public static void Load(Scene targerScene)
    {
        Loader.targetScene = targerScene;
        SceneManager.LoadScene(Loader.Scene.LoaderScene.ToString());
    }

    public static void LoaderCallback()
    {
        SceneManager.LoadScene(targetScene.ToString());
    }
}
