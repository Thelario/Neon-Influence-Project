using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Shop : MonoBehaviour
{
	public List<Product> products;

	public TMP_Text currencyText;

	public GameObject productsPanel;

	private void Start()
	{
		products.Clear();

		foreach (Transform t in productsPanel.transform)
		{
			products.Add(t.GetComponent<Product>());
		}
	}

	private void OnEnable()
	{
		currencyText.text = MetaCurrencyData.Instance.MetaCurrencyAmount.ToString();
	}

	public void BuyProduct(int productID)
	{
		// We find the product throguh its ID
		Product p = products.Find(product => product.productID == productID);

		// We check if player can buy the product chosen and if he doesn't own the product already
		if (p.price <= MetaCurrencyData.Instance.MetaCurrencyAmount && !p.owned)
		{
			MetaCurrencyData.Instance.DecreaseMetaCurrency(p.price);
			p.owned = true;
			p.priceText.text = "Owned";
			currencyText.text = MetaCurrencyData.Instance.MetaCurrencyAmount.ToString();
			ColorSchemeManager.Instance.AddColorScheme(productID);
		}
		else
		{
			// Make some kind of error appear when buying a product already owned
			Debug.Log("Cannot buy product");
		}
	}
}
