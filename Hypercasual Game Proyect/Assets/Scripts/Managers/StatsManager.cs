using UnityEngine;

public class StatsManager : MonoBehaviour
{
	private static StatsManager _instance;
	public static StatsManager Instance
	{
		get
		{
			if (_instance == null)
				Debug.LogError("StatsManager is NULL");

			return _instance;
		}
	}

	public float slowEnemyMoveSpeed;
	public float normalEnemyMoveSpeed;
	public float fastEnemyMoveSpeed;

	public int slowScoreReward;
	public int normalScoreReward;
	public int fastScoreReward;

	//[Range(0.1f, 0.9f)]
	//public float enemySlowReduction;

	private void Awake()
	{
		if (_instance != null)
		{
			Destroy(_instance.gameObject);
		}

		_instance = this;
	}
}
