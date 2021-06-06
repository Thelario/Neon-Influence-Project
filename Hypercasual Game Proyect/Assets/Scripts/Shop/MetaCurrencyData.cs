using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaCurrencyData : MonoBehaviour
{
	public static MetaCurrencyData Instance { get; private set; }

	public int MetaCurrencyAmount { get; private set; }

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;

			LoadMetaCurrencyData();
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void IncreaseMetaCurrency()
	{
		MetaCurrencyAmount++;

		SaveMetaCurrencyData();
	}

	public void DecreaseMetaCurrency(int amount)
	{
		MetaCurrencyAmount -= amount;

		SaveMetaCurrencyData();
	}

	public void SaveMetaCurrencyData()
	{
		PlayerPrefs.SetInt("metaCurrencyAmount", MetaCurrencyAmount);
		PlayerPrefs.Save();
	}

	public void LoadMetaCurrencyData()
	{
		MetaCurrencyAmount = PlayerPrefs.GetInt("metaCurrencyAmount");
	}
}
