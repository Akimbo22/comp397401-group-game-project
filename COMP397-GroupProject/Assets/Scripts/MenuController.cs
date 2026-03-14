using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject startGame;
    public GameObject options;
    public GameObject quitGame;
    public GameObject optionsWindow;
    public GameObject talkBanker;
    public GameObject talkBarkeep;
    public GameObject talkSheriff;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startGame.SetActive(true);
        options.SetActive(false);
        quitGame.SetActive(false);
        optionsWindow.SetActive(false);
        talkBanker.SetActive(false);
        talkBarkeep.SetActive(false);
        talkSheriff.SetActive(false);
    }


    public void OnPlayGame()
    {
        SceneManager.LoadScene("Wave 1-1");
    }


    public void OpenOptions()
    {
        optionsWindow.SetActive(true);
    }

    public void OnQuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }


    public void SwitchToBanker()
    {
        startGame.SetActive(false);
        options.SetActive(true);
        quitGame.SetActive(false);
        optionsWindow.SetActive(false);
        talkBanker.SetActive(false);
        talkBarkeep.SetActive(false);
        talkSheriff.SetActive(false);
    }

    public void SwitchToSheriff()
    {
        startGame.SetActive(true);
        options.SetActive(false);
        quitGame.SetActive(false);
        optionsWindow.SetActive(false);
        talkBanker.SetActive(false);
        talkBarkeep.SetActive(false);
        talkSheriff.SetActive(false);
    }

    public void SwitchToBarkeep()
    {
        startGame.SetActive(false);
        options.SetActive(false);
        quitGame.SetActive(true);
        optionsWindow.SetActive(false);
        talkBanker.SetActive(false);
        talkBarkeep.SetActive(false);
        talkSheriff.SetActive(false);
    }

    public void TalkBanker()
    {
        talkBanker.SetActive(true);
    }

    public void TalkSheriff()
    {
        talkSheriff.SetActive(true);
    }
    public void TalkBarkeep()
    {
        talkBarkeep.SetActive(true);
    }
    public void CloseDialogue()
    {
        talkBanker.SetActive(false);
        talkSheriff.SetActive(false);
        talkBarkeep.SetActive(false);
        optionsWindow.SetActive(false);
    }
}
