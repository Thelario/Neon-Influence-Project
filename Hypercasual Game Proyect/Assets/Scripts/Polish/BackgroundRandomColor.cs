using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRandomColor : MonoBehaviour
{
	SpriteRenderer spriteRenderer;
	
	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Start()
    {
		spriteRenderer.color = ColorSchemeManager.Instance.selectedColorScheme.backgroundColor;
    }
}
