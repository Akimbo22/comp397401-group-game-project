using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip titleMusic;
    [SerializeField] private AudioClip menusMusic;
    [SerializeField] private AudioClip gameOverMusic;
    [SerializeField] private AudioClip gameWinMusic;
    [SerializeField] private AudioClip levelMusic;
    [SerializeField] private AudioClip buttonSFX;
    [SerializeField] private AudioClip hitSFX;
    [SerializeField] private AudioClip shootSFX;
    [SerializeField] private AudioClip deathSFX;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;


    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        string sceneName = scene.name;
        PlayBGMusic(sceneName);
    }

    public void PlayButtonSFX()
    {
        sfxSource.clip = buttonSFX;
        sfxSource.Play();
    }

    public void PlayHitSFX()
    {
        sfxSource.clip = hitSFX;
        sfxSource.Play();
    }
    public void PlayShootSFX()
    {
        sfxSource.clip = shootSFX;
        sfxSource.Play();
    }
    public void PlayDeathSFX()
    {
        sfxSource.clip = deathSFX;
        sfxSource.Play();
    }

    public void PlayBGMusic(string scene)
    {
        if(scene == "TitleScene")
        {
            musicSource.clip = titleMusic;
            musicSource.Play();
        }
        else if(scene == "MenuScene")
        {
            musicSource.clip = menusMusic;
            musicSource.Play();
        }
        else if( scene == "GameOverScene")
        {
            musicSource.clip = gameOverMusic;
            musicSource.Play();
        }
        else if(scene == "gameWinScene")
        {
            musicSource.clip = gameWinMusic;
            musicSource.Play();
        }
        else
        {
            musicSource.clip = levelMusic;
            musicSource.Play();
        }
    }
    
}
