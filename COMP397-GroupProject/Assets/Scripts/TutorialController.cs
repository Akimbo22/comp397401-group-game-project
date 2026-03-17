using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    public GameObject tutorialScreen;
    public GameObject tutorialWindow1;
    public GameObject tutorialWindow2;
    public GameObject tutorialWindow3;
    public GameObject tutorialWindow4;
    public GameObject tutorialWindow5;
    public GameObject tutorialWindow6;
    public GameObject tutorialWindow7;
    public GameObject tutorialWindow8;
    private int numWindows = 8;
    private int windowCounter = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tutorialScreen.SetActive(false);
        tutorialWindow1.SetActive(false);
        tutorialWindow2.SetActive(false);
        tutorialWindow3.SetActive(false);
        tutorialWindow4.SetActive(false);
        tutorialWindow5.SetActive(false);
        tutorialWindow6.SetActive(false);
        tutorialWindow7.SetActive(false);
        tutorialWindow8.SetActive(false);
        
    }

    public void OnOpenTutorial()
    {
        tutorialScreen.SetActive(true);
        tutorialWindow1.SetActive(true);
    }
    public void OnCloseTutorial()
    {
        tutorialScreen.SetActive(false);
        tutorialWindow1.SetActive(false);
        tutorialWindow2.SetActive(false);
        tutorialWindow3.SetActive(false);
        tutorialWindow4.SetActive(false);
        tutorialWindow5.SetActive(false);
        tutorialWindow6.SetActive(false);
        tutorialWindow7.SetActive(false);
        tutorialWindow8.SetActive(false);
        windowCounter = 1;
    }
    public void NextWindow()
    {
        Debug.Log("Next");
        if(windowCounter < numWindows)
        {
            if(tutorialWindow1.activeInHierarchy)
            {
                tutorialWindow1.SetActive(false);
                tutorialWindow2.SetActive(true);
            }
            else if(tutorialWindow2.activeInHierarchy)
            {
                tutorialWindow2.SetActive(false);
                tutorialWindow3.SetActive(true);
            }
            else if(tutorialWindow3.activeInHierarchy)
            {
                tutorialWindow3.SetActive(false);
                tutorialWindow4.SetActive(true);
            }
            else if(tutorialWindow4.activeInHierarchy)
            {
                tutorialWindow4.SetActive(false);
                tutorialWindow5.SetActive(true);
            }
            else if(tutorialWindow5.activeInHierarchy)
            {
                tutorialWindow5 .SetActive(false);
                tutorialWindow6.SetActive(true);
            }
            else if(tutorialWindow6.activeInHierarchy)
            {
                tutorialWindow6 .SetActive(false);
                tutorialWindow7.SetActive(true);
            }
            else if(tutorialWindow7.activeInHierarchy)
            {
                tutorialWindow7.SetActive(false);
                tutorialWindow8.SetActive(true);
            }
            windowCounter++;
        }
    }
    public void PrevWindow()
    {
        Debug.Log("Previous");
        if (windowCounter > 1)
        {
            if(tutorialWindow8.activeInHierarchy)
            {
                tutorialWindow8.SetActive(false);
                tutorialWindow7.SetActive(true);
            }
            else if(tutorialWindow7.activeInHierarchy)
            {
                tutorialWindow7.SetActive(false);
                tutorialWindow6.SetActive(true);
            }
            else if(tutorialWindow6.activeInHierarchy)
            {
                tutorialWindow6.SetActive(false);
                tutorialWindow5.SetActive(true);
            }
            else if(tutorialWindow5.activeInHierarchy)
            {
                tutorialWindow5.SetActive(false);
                tutorialWindow4.SetActive(true);
            }
            else if(tutorialWindow4.activeInHierarchy)
            {
                tutorialWindow4.SetActive(false);
                tutorialWindow3.SetActive(true);
            }
            else if(tutorialWindow3.activeInHierarchy)
            {
                tutorialWindow3.SetActive(false);
                tutorialWindow2.SetActive(true);
            }
            else if(tutorialWindow2.activeInHierarchy)
            {
                tutorialWindow2.SetActive(false);
                tutorialWindow1.SetActive(true);
            }
            windowCounter--;
        }
    }
}
