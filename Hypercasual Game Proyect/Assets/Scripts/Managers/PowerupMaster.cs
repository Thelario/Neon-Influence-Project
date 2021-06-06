using UnityEngine;

public class PowerupMaster : MonoBehaviour
{
	public delegate void Powerup();

	public static event Powerup OnSlowingOfEnemies;
	public static event Powerup OnInvencibility;
	public static event Powerup OnScoreMultiplier;
	public static event Powerup DeApplyPowerups;

    public void SlowingOfEnemies()
	{
		OnSlowingOfEnemies();
	}

	public void Invencibility()
	{
		OnInvencibility?.Invoke();
	}

	public void ScoreMultuplier()
	{
		OnScoreMultiplier();
	}

	public void DeApplyPowerup()
	{
		DeApplyPowerups();
	}
}
