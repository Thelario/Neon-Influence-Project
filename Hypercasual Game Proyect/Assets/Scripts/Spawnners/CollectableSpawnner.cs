using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawnner : MonoBehaviour
{
	public static CollectableSpawnner Instance { get; private set; }

	public GameObject collectablePrefab;
	public GameObject metaCurrencyPrefab;

	public float horizontalMaxLimit;
	public float verticalMaxLimit;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		SpawnCollectable();
	}

	public void SpawnCollectable()
	{
		Vector2 positionToSpawn = GetNewPosition();

		//int random = Random.Range(0, 10);
		
		//if (random >= 8)
		//{
		//	Instantiate(metaCurrencyPrefab, positionToSpawn, Quaternion.identity);
		//}
		//else
		//{
			Instantiate(collectablePrefab, positionToSpawn, Quaternion.identity);
		//}
	}

	Vector2 GetNewPosition()
	{
		float x = Random.Range(-horizontalMaxLimit, horizontalMaxLimit);
		float y = Random.Range(-verticalMaxLimit, verticalMaxLimit);

		return new Vector2(x, y);
	}
}
