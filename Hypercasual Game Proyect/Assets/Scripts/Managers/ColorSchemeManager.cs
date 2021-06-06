using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class ColorScheme
{
	public int colorSchemeID;

	public Color backgroundColor;
	public Color slowEnemyColor;
	public Color normalEnemyColor;
	public Color fastEnemyColor;
}

public class ColorSchemeManager : MonoBehaviour
{
	private static ColorSchemeManager _instance;
	public static ColorSchemeManager Instance
	{
		get
		{
			if (_instance == null)
				Debug.LogError("ColorSchemeManager is NULL");
			
			return _instance;
		}
	}

	public List<ColorScheme> colorSchemeList;
	public List<ColorScheme> availableColorSchemes;

	public ColorScheme selectedColorScheme;

	//private int random = 0;

	private void Awake()
	{
		if (_instance == null)
		{
			_instance = this;
			//LoadColorSchemeData();
			//selectedColorScheme = availableColorSchemes[0];
		}
		else
		{
			Destroy(gameObject);
		}
	}

	private void OnLevelWasLoaded(int level)
	{
		SelectRandomColor();
	}

	public void AddColorScheme(int colorSchemeID)
	{
		foreach (ColorScheme c in colorSchemeList)
		{
			if (c.colorSchemeID == colorSchemeID)
			{
				availableColorSchemes.Add(c);
				selectedColorScheme = c;
				SaveColorSchemeData();
			}
		}
	}

	public void SelectRandomColor()
	{
		selectedColorScheme = GetColorSchemeFromWhole(Random.Range(0, colorSchemeList.Count));
	}

	public ColorScheme GetColorSchemeFromWhole(int colorSchemeID)
	{
		foreach (ColorScheme colorScheme in colorSchemeList)
		{
			if (colorScheme.colorSchemeID == colorSchemeID)
			{
				return colorScheme;
			}
		}

		return null;
	}

	public ColorScheme GetColorScheme(int colorSchemeID)
	{
		foreach (ColorScheme colorScheme in availableColorSchemes)
		{
			if (colorScheme.colorSchemeID == colorSchemeID)
			{
				return colorScheme;
			}
		}
		Debug.Log("NULL");
		return null;
	}

	public void SaveColorSchemeData()
	{
		foreach (ColorScheme colorScheme in availableColorSchemes)
		{
			PlayerPrefs.SetInt("ColorScheme_" + colorScheme.colorSchemeID, colorScheme.colorSchemeID);
		}

		PlayerPrefs.Save();
	}

	public void LoadColorSchemeData()
	{
		int i = 0;
		foreach (ColorScheme colorScheme in colorSchemeList)
		{
			if (PlayerPrefs.HasKey("ColorScheme_" + i))
			{
				AddColorScheme(PlayerPrefs.GetInt("ColorScheme_" + i));
			}

			i++;
		}
	}
}
