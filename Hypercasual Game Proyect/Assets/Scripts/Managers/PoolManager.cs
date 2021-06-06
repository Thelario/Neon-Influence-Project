using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { SLOW, NORMAL, FAST }

public class PoolManager : MonoBehaviour
{
	private static PoolManager _instance;
	public static PoolManager Instance
	{
		get
		{
			if (_instance == null)
				Debug.LogError("PoolManager is NULL");

			return _instance;
		}
	}

	public GameObject slowEnemyContainer;
	public GameObject slowEnemyPrefab;
	public List<GameObject> slowEnemyPool;

	public GameObject normalEnemyContainer;
	public GameObject normalEnemyPrefab;
	public List<GameObject> normalEnemyPool;

	public GameObject fastEnemyContainer;
	public GameObject fastEnemyPrefab;
	public List<GameObject> fastEnemyPool;

	private void Awake()
	{
		_instance = this;
	}
	
	IEnumerator Start()
    {
		yield return new WaitForSecondsRealtime(3f);

		slowEnemyPool = GenerateEnemies(10, EnemyType.SLOW);
		normalEnemyPool = GenerateEnemies(10, EnemyType.NORMAL);
		fastEnemyPool = GenerateEnemies(10, EnemyType.FAST);
    }

    List<GameObject> GenerateEnemies(int amountOfEnemies, EnemyType enemyType)
	{
		if (enemyType == EnemyType.SLOW)
		{
			CreateEnemies(amountOfEnemies, slowEnemyPrefab, slowEnemyContainer, slowEnemyPool);

			return slowEnemyPool;
		}
		else if (enemyType == EnemyType.NORMAL)
		{
			CreateEnemies(amountOfEnemies, normalEnemyPrefab, normalEnemyContainer, normalEnemyPool);

			return normalEnemyPool;
		}
		else if (enemyType == EnemyType.FAST)
		{
			CreateEnemies(amountOfEnemies, fastEnemyPrefab, fastEnemyContainer, fastEnemyPool);

			return fastEnemyPool;
		}
		else
		{
			Debug.LogError("Some problem occured when trying to generate enemies. Not assigning correctly the enemy type???");
			return null;
		}
	}

	private void CreateEnemies(int amountOfEnemies, GameObject enemyPrefab, GameObject enemyContainer, List<GameObject> enemyPool)
	{
		for (int i = 0; i < amountOfEnemies; i++)
		{
			GameObject enemy = Instantiate(enemyPrefab);             // Creating the enemy
			enemy.transform.SetParent(enemyContainer.transform);     // Assigning the parent
			enemyPool.Add(enemy);                                    // Adding the enemy to the pool
			enemy.SetActive(false);                                  // Deactivating the enemy
		}
	}

	public GameObject RequestEnemy(EnemyType enemyType)
	{
		if (enemyType == EnemyType.SLOW)
		{
			return SearchForEnemy(slowEnemyPool, enemyType);
		}
		else if (enemyType == EnemyType.NORMAL)
		{
			return SearchForEnemy(normalEnemyPool, enemyType);
		}
		else if (enemyType == EnemyType.FAST)
		{
			return SearchForEnemy(fastEnemyPool, enemyType);
		}
		else
		{
			Debug.LogError("Some problem occured when requesting an enemy");
			return null;
		}
	}

	private GameObject SearchForEnemy(List<GameObject> enemyPool, EnemyType enemyType)
	{
		foreach (GameObject enemy in enemyPool)
		{
			if (!enemy.activeInHierarchy)
			{
				enemy.SetActive(true);
				return enemy;
			}
		}

		enemyPool = GenerateEnemies(1, enemyType);
		return SearchForEnemy(enemyPool, enemyType);
	}
}
