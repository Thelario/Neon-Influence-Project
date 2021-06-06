using UnityEngine;
using UnityEngine.UI;

public class PowerupManager : MonoBehaviour
{
	private static PowerupManager _instance;
	public static PowerupManager Instance
	{
		get
		{
			if (_instance == null)
				Debug.LogError("PowerupManager is NULL");

			return _instance;
		}
	}

	public Slider powerupSlider;
	public Text powerupText;

	public int scoreForNextPowerup;

	private int currentPowerupScore;
	private bool hasPowerup = false;

	public float timeToUsePowerup;
	private float timeToUsePowerupCounter;

	private PowerupMaster powerupMaster;

	private void Awake()
	{
		if (_instance != null)
		{
			Destroy(_instance.gameObject);
		}

		_instance = this;
	}

	void Start()
    {
		powerupMaster = GetComponent<PowerupMaster>();

		powerupSlider.maxValue = scoreForNextPowerup;
		powerupSlider.value = 0f;
		timeToUsePowerupCounter = timeToUsePowerup;
    }
	
    void Update()
    {
        if (hasPowerup == true)
		{
			timeToUsePowerupCounter -= Time.deltaTime;
			powerupSlider.value = timeToUsePowerupCounter;

			if (timeToUsePowerupCounter <= 0f)
			{
				DeApplyPowerup();
			}
		}
    }

	public void UpdateCurrentScore(int scoreToAdd)
	{
		if (hasPowerup == false)
		{
			currentPowerupScore += scoreToAdd;
			powerupSlider.value = currentPowerupScore;

			if (currentPowerupScore >= scoreForNextPowerup)
			{
				ApplyPowerup();
			}
		}
	}

	private void ApplyPowerup()
	{
		int random = Random.Range(0, 3);

		if (random == 0)
			powerupMaster.Invencibility();
		else if (random == 1)
			powerupMaster.ScoreMultuplier();
		else if (random == 2)
			powerupMaster.SlowingOfEnemies();

		UpdatePowerup(timeToUsePowerup, timeToUsePowerup, true);
	}

	private void DeApplyPowerup()
	{
		powerupMaster.DeApplyPowerup();

		UpdatePowerup(scoreForNextPowerup, 0f, false);
		currentPowerupScore = 0;
	}

	private void UpdatePowerup(float sliderMaxValue, float sliderValue, bool powerupActivate)
	{
		powerupSlider.maxValue = sliderMaxValue;
		powerupSlider.value = sliderValue;
		hasPowerup = powerupActivate;
		powerupText.gameObject.SetActive(powerupActivate);
	}
}
