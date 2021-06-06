using System.Collections;
using UnityEngine;

public class EnemySpawnner : MonoBehaviour
{
	public float topAndDownLimitToSpawn;
	public float leftAndRightLimitToSpawn;
	public float spawnOffset;

	public float timeBetweenEachEnemySpawnned; // This field should be in a stats manager or smth

	private float enemyAngleToRotate;

	public Camera cam;

	private void Start()
	{
		StartCoroutine(SpawnerLoop(timeBetweenEachEnemySpawnned));
	}

	IEnumerator SpawnerLoop(float timeDelayed)
	{
		int randomEnemyNumber = Random.Range(0, 3);

		GameObject enemyToSpawn;

		if (randomEnemyNumber == 0)
		{
			enemyToSpawn = PoolManager.Instance.RequestEnemy(EnemyType.SLOW);
		}
		else if (randomEnemyNumber == 1)
		{
			enemyToSpawn = PoolManager.Instance.RequestEnemy(EnemyType.NORMAL);
		}
		else 
		{
			enemyToSpawn = PoolManager.Instance.RequestEnemy(EnemyType.FAST);
		}

		enemyToSpawn.transform.position = CalculateNewPositionToSpawn();
		enemyToSpawn.GetComponent<Enemy>().SetRotation(enemyAngleToRotate);

		yield return new WaitForSeconds(timeDelayed);

		StartCoroutine(SpawnerLoop(timeDelayed));
	}

	Vector2 CalculateNewPositionToSpawn()
	{
		int randomSpawnSide = Random.Range(0, 4);

		float x;
		float y;

		float height = cam.orthographicSize;
		float width = height * cam.aspect;

		switch (randomSpawnSide)
		{
			case 0: // Left side
				x = Random.Range(-leftAndRightLimitToSpawn, -width);
				y = Random.Range(-height - spawnOffset, height + spawnOffset);
				enemyAngleToRotate = 0f;
				break;
			case 1: // Right side
				x = Random.Range(width, leftAndRightLimitToSpawn);
				y = Random.Range(-height - spawnOffset, height + spawnOffset);
				enemyAngleToRotate = 180;
				break;
			case 2: // Up side
				x = Random.Range(-width - spawnOffset, width + spawnOffset);
				y = Random.Range(height, topAndDownLimitToSpawn);
				enemyAngleToRotate = -90f;
				break;
			case 3: // Down side / In case there is any error, the enemy will spawn in the down side
			default:
				x = Random.Range(-width - spawnOffset, width + spawnOffset);
				y = Random.Range(-topAndDownLimitToSpawn, -height);
				enemyAngleToRotate = 90f;
				break;
		}

		return new Vector2(x, y);
	}
}
