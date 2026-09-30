using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("General")]
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitParticles;

    [Header("Effects")]
    [SerializeField] bool applyCameraShake;

    [Header("Score Tracking")]
    [SerializeField] bool isNPC;
    [SerializeField] int scoreToAdd = 10;
    ScoreKeeper scoreKeeper;

    ScreenShake screenShake;
    AudioManager audioManager;
    LevelManager levelManager;

    public int GetHealth()
    {
        return health;
    }

    void Start()
    {
        screenShake = Camera.main.GetComponent<ScreenShake>();
        audioManager = FindFirstObjectByType<AudioManager>();
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        levelManager = FindFirstObjectByType<LevelManager>();
    }    

    void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        if (damageDealer == null) return;

        TakeDamage(damageDealer.GetDamage());
        PlayHitParticles();
        damageDealer.Hit();
        
        if (applyCameraShake)
        {
            screenShake.Play();
        }

        audioManager.PlayDamageSFX();
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isNPC)
        {
            scoreKeeper.AddScore(scoreToAdd);
        }
        else
        {
            levelManager.LoadGameOver();
        }

        Destroy(gameObject);
    }

    void PlayHitParticles()
    {
        if (hitParticles != null)
        {
            ParticleSystem particles = Instantiate(hitParticles, transform.position, Quaternion.identity);
            Destroy(particles, particles.main.duration + particles.main.startLifetime.constantMax);
        }
    }
}
