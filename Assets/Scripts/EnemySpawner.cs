using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigSO[] waveConfigs;
    [SerializeField] float timeBetweenWaves;
    [SerializeField] bool isLooping;

    WaveConfigSO currentWave;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        do
        {
            foreach (WaveConfigSO waveConfig in waveConfigs)
            {
                currentWave = waveConfig;

                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(
                        currentWave.GetEnemyPrefab(i),
                        currentWave.GetStartingWaypoint().transform.position,
                        Quaternion.identity,
                        transform
                    );

                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }

                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping);
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
}
