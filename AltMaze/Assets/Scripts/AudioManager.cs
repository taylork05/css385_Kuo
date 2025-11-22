using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("_____Audio Sources_____")]
    public AudioSource musicSource;  // Make sure to assign this in the Inspector
    public AudioSource SFXSource;

    [Header("_____Audio Clips_____")]
    public AudioClip background;
    public AudioClip keyCollected;
    public AudioClip win;
    public AudioClip GetOutTrigger;


    public static AudioManager instance;

    private void Awake()
    {
        // Singleton pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // Start background music here to avoid timing issues
            if (musicSource != null && background != null)
            {
                musicSource.clip = background;
                musicSource.loop = true; // ensures it loops
                musicSource.Play();
            }
            else
            {
                Debug.LogWarning("AudioSource or background clip is not assigned!");
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (SFXSource != null && clip != null)
            SFXSource.PlayOneShot(clip);
    }
}
