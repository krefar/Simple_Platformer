using Assets.Scripts.UI;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManipulator : MonoBehaviour
{
    public void OpenGameScene()
    {
        var gameScene = SceneManager.GetSceneByBuildIndex((int)ScenesEnum.GameScene);

        if (gameScene.isLoaded)
        {
            var activeSceneIndex = SceneManager.GetActiveScene().buildIndex;

            if (activeSceneIndex == (int)ScenesEnum.GameScene)
            {
                SceneManager.UnloadSceneAsync(++activeSceneIndex);
            }
            else
            {
                CloseActiveScene();
            }
        }
        else
        {
            SceneManager.LoadScene((int)ScenesEnum.GameScene);
        }
    }

    public void OpenMainMenuScene()
    {
        var mainMenuIndex = (int)ScenesEnum.MainMenu;
        var mainMenu = SceneManager.LoadScene(mainMenuIndex, new LoadSceneParameters() { loadSceneMode = LoadSceneMode.Additive });

        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    public void OpenAuthorsScene()
    {
        var authorsIndex = (int)ScenesEnum.Authors;
        var authors = SceneManager.LoadScene(authorsIndex, new LoadSceneParameters() { loadSceneMode = LoadSceneMode.Additive });

        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    public void CloseActiveScene()
    {
        var activeSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.UnloadSceneAsync(activeSceneIndex);
    }

    public void Exit()
    {
        var activeSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (SceneManager.loadedSceneCount == 1 && activeSceneIndex == (int)ScenesEnum.MainMenu)
        {
            EditorApplication.ExitPlaymode();
        }

        CloseAllScenes();
    }

    private void CloseAllScenes()
    {
        var allScenesIndex = SceneManager.GetAllScenes().Select(scene => scene.buildIndex);
        foreach (var sceneIndex in allScenesIndex)
        {
            SceneManager.UnloadScene(sceneIndex);
        }
    }

    private void SceneManager_sceneLoaded(Scene scene, LoadSceneMode arg1)
    {
        SceneManager.SetActiveScene(scene);
        SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
    }
}