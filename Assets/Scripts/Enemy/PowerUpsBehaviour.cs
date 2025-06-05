using UnityEngine;

public class PowerUpsBehaviour : MonoBehaviour
{
    [SerializeField] LeanTweenType animType;
    float animDuration = 1f;
    float animScale = 0.5f;

    private void Start()
    {
        LeanTween.moveLocalY(gameObject, transform.position.y + animScale, animDuration).setEase(animType).setLoopPingPong();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("InfiniteEnergy"))
            {
                EnergySystem.instance.InfiniteEnergyPowerUp();
            }
            else if (gameObject.CompareTag("FullReload"))
            {
                EnergySystem.instance.FullReloadPowerUp();
            }

            Destroy(gameObject);
        }
    }
}
