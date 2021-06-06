using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Product : MonoBehaviour
{
	public Image backgroundImage;
	public Image slowEnemyImage;
	public Image normalEnemyImage;
	public Image fastEnemyImage;

	public TMP_Text priceText;

	public int productID;
	public bool owned = false;
	public int price;

	private void Start()
	{
		ColorScheme scheme = ColorSchemeManager.Instance.GetColorSchemeFromWhole(productID);

		backgroundImage.color = scheme.backgroundColor;
		slowEnemyImage.color = scheme.slowEnemyColor;
		normalEnemyImage.color = scheme.normalEnemyColor;
		fastEnemyImage.color = scheme.fastEnemyColor;

		if (price == 0)
		{
			priceText.text = "Owned";
			owned = true;
		}
		else
		{
			priceText.text = price.ToString();
		}
	}
}
