using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioClip backgroundMusic;
    public AudioClip coinSound;
    public AudioClip jumpSound;
    public AudioClip damageSound;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        playMusic(backgroundMusic);
        /* Used to change music for different scenes, unused currently
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            ChangeMusic(backgroundMusic);
        }
        else if (SceneManager.GetActiveScene().name == "GameScene")
        {
            ChangeMusic(backgroundMusic);
        }
        */
    }
    

    public void playMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    private void OnEnable()
    {
        Debug.Log($"AudioManager enabled, subscribing to GameManager events: {GameManager.Instance}");
        GameManager.Instance.OnHealthChanged += playDamageSound;
        GameManager.Instance.OnScoreChanged += playCoinSound;
    }
    private void OnDisable()
    {
        GameManager.Instance.OnHealthChanged -= playDamageSound;
        GameManager.Instance.OnScoreChanged -= playCoinSound;
    }

    void playDamageSound(int newHealth)
    {
        PlaySound(damageSound);
    }

    void playCoinSound(int newScore)
    {
        PlaySound(coinSound, 1.75f);
    }

    public void PlaySound(AudioClip clip, float volume = 1f)
    {
        sfxSource.PlayOneShot(clip, volume);
    }

    public void ChangeMusic(AudioClip newMusic)
    {
        if (musicSource.clip == newMusic) return; 
        musicSource.Stop();
        playMusic(newMusic);
    }
}
