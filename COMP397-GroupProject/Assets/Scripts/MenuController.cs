using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject startGame;

    public GameObject loadGame;
    [SerializeField] private Button loadBtn;

    public GameObject options;
    public GameObject quitGame;
    public GameObject optionsWindow;
    public GameObject talkBanker;
    public GameObject talkBarkeep;
    public GameObject talkFather;
    public GameObject talkSheriff;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startGame.SetActive(true);
        loadGame.SetActive(false);
        options.SetActive(false);
        quitGame.SetActive(false);
        optionsWindow.SetActive(false);
        talkBanker.SetActive(false);
        talkFather.SetActive(false);
        talkBarkeep.SetActive(false);
        talkSheriff.SetActive(false);

        loadBtn.onClick.AddListener(() =>
        {
            SaveLoadSystem.Instance.LoadGame("Wave 1-2");
        });
    }


    public void OnPlayGame()
    {
        SceneManager.LoadScene("Wave 1-1Alt");
    }

    public void OnLoadGame()
    {
        Debug.Log("Load Game button clicked");
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

    public void SwitchToFather()
    {
        startGame.SetActive(false);
        loadGame.SetActive(true);
        options.SetActive(false);
        quitGame.SetActive(false);
        optionsWindow.SetActive(false);
        talkFather.SetActive(false);
        talkBanker.SetActive(false);
        talkBarkeep.SetActive(false);
        talkSheriff.SetActive(false);
    }


    public void SwitchToBanker()
    {
        startGame.SetActive(false);
        loadGame.SetActive(false);
        options.SetActive(true);
        quitGame.SetActive(false);
        optionsWindow.SetActive(false);
        talkBanker.SetActive(false);
        talkBarkeep.SetActive(false);
        talkSheriff.SetActive(false);
        talkFather.SetActive(false);
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

    public void TalkFather()
    {
        talkFather.SetActive(true);
    }
    public void CloseDialogue()
    {
        talkBanker.SetActive(false);
        talkSheriff.SetActive(false);
        talkBarkeep.SetActive(false);
        talkFather.SetActive(false);
        optionsWindow.SetActive(false);
    }
}
