using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    public void OnStartClick()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void OnExitClick()
    {
        // When clicking exit, if you are in the Unity Editor, it shuts down the test, if you are in a built game, it shuts off the game
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
