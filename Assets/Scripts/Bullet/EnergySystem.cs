using System;
using TMPro;
using UnityEngine;

public class EnergySystem : MonoBehaviour
{
    public static EnergySystem instance;

    [SerializeField] float startEnergy;

    [SerializeField] float energyAddedPerSecond;
    [SerializeField] float energyWastedPerShot;

    [SerializeField] float maxEnergyPercentage = 100f;

    [SerializeField] float infiniteEnergyDuration;
    [SerializeField] string infiniteEnergyText;

    float infiniteEnergyCounter = 0f;

    float currentEnergy;

    bool infiniteEnergy = false;

    [SerializeField] TextMeshProUGUI energyText;

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

    private void Start()
    {
        currentEnergy = startEnergy;
        UpdateEnergyText();
    }

    void Update()
    {
        if (infiniteEnergy)
        {
            EnergyCounter();
        }

        AutomaticEnergyReload();
    }

    void EnergyCounter()
    {
        infiniteEnergyCounter += Time.deltaTime;

        if (infiniteEnergyCounter >= infiniteEnergyDuration)
        {
            infiniteEnergyCounter = 0f;
            infiniteEnergy = false;
            UpdateEnergyText();
        }
    }

    void AutomaticEnergyReload()
    {
        if (currentEnergy < maxEnergyPercentage)
        {
            currentEnergy += Time.deltaTime * energyAddedPerSecond;
            UpdateEnergyText();
        }
    }

    public void ConsumeShotEnergy()
    {
        if (!infiniteEnergy)
        {
            currentEnergy -= energyWastedPerShot;
            UpdateEnergyText();
        }
    }

    void UpdateEnergyText()
    {
        if (!infiniteEnergy)
        {
            energyText.text = currentEnergy.ToString("00");
        }
    }

    public bool HasEnoughEnergy()
    {
        if (currentEnergy >= energyWastedPerShot)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void InfiniteEnergyPowerUp()
    {
        infiniteEnergy = true;
        energyText.text = infiniteEnergyText;
        currentEnergy = maxEnergyPercentage;
    }

    public void FullReloadPowerUp()
    {
        currentEnergy = maxEnergyPercentage;
        UpdateEnergyText();
    }
}
