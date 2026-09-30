using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Shooting SFX")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField][Range(0f, 1f)] float shootingVolume;

    [Header("Damage SFX")]
    [SerializeField] AudioClip damageClip;
    [SerializeField][Range(0f, 1f)] float damageVolume;

    static AudioManager instance;

    private void Awake()
    {
        ManageSingletone();
    }

    void ManageSingletone()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    public void PlayShootingSFX()
    {
        PlayAudioClip(shootingClip, shootingVolume);
    }

    public void PlayDamageSFX()
    {
        PlayAudioClip(damageClip, damageVolume);
    }

    void PlayAudioClip(AudioClip audioClip, float volume)
    {
        if (audioClip != null)
        {
            AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, volume);
        }
        {
            
        }
    }
}
