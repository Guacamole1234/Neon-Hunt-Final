using UnityEngine;

public class PowerUpSpawnBehaviour : MonoBehaviour
{
    public static PowerUpSpawnBehaviour instance;

    [SerializeField] float infinitePowerUpSpawnChance;
    [SerializeField] float fullReloadPowerUpSpawnChance;

    [SerializeField] float addedYSpawn = 3f;

    [SerializeField] GameObject infinitePowerUpPrefab;
    [SerializeField] GameObject fullReloadPowerUpPrefab;

    float maxPercentage = 100f;
    bool powerUpSelected = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void SelectRandomPowerUp(Vector3 spawnPos)
    {
        spawnPos.y += addedYSpawn;

        if (fullReloadPowerUpSpawnChance >= Random.Range(0f, maxPercentage))
        {
            Instantiate(fullReloadPowerUpPrefab, spawnPos, Quaternion.identity);
            powerUpSelected = true;
        }

        if (!powerUpSelected && infinitePowerUpSpawnChance >= Random.Range(0f, maxPercentage))
        {
            Instantiate(infinitePowerUpPrefab, spawnPos, Quaternion.identity);
        }

        powerUpSelected = false;
    }
}
