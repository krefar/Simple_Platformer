using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
    public class UIInput : MonoBehaviour
    {
        [SerializeField] private SceneManipulator _sceneOpener;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (SceneManager.GetActiveScene().buildIndex != (int)ScenesEnum.MainMenu)
                {
                    _sceneOpener.OpenMainMenuScene();
                }
            }
        }
    }
}
