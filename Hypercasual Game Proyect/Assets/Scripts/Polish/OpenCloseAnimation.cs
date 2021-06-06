using UnityEngine;

public class OpenCloseAnimation : MonoBehaviour
{
	RectTransform rectTransform;
	Vector2 previousScale;
	Vector2 previousLocalPos;

	[Header("Animation Time")]
	public float duration;
	public float delay;

	[Header("Local Movement")]
	public float xOffset;
	public float yOffset;

	[Header("Scale")]
	public bool scale = false;

	[Header("Whole Rotation")]
	public bool hasWholeRotation = false;

	[Header("SFX")]
	public bool applySFX;
	public AudioClip openCloseSFX;

	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
		previousScale = rectTransform.localScale;
		previousLocalPos = transform.localPosition;
	}

	private void OnEnable()
	{
		if (scale)
		{
			transform.localScale = Vector3.zero;
			LeanTween.scale(rectTransform, previousScale, duration).setDelay(delay).setIgnoreTimeScale(true);

			if (SoundManager.Instance != null && applySFX) { SoundManager.Instance.PlaySFX(openCloseSFX); }
		}

		if (xOffset != 0f)
		{
			LeanTween.moveLocalX(gameObject, previousLocalPos.x + xOffset, 0f).setIgnoreTimeScale(true);
			LeanTween.moveLocalX(gameObject, previousLocalPos.x, duration).setDelay(delay).setIgnoreTimeScale(true);

			if (SoundManager.Instance != null && applySFX) { SoundManager.Instance.PlaySFX(openCloseSFX); }
		}

		if (yOffset != 0f)
		{
			LeanTween.moveLocalY(gameObject, previousLocalPos.y + yOffset, 0f).setIgnoreTimeScale(true);
			LeanTween.moveLocalY(gameObject, previousLocalPos.y, duration).setDelay(delay).setIgnoreTimeScale(true);

			if (SoundManager.Instance != null && applySFX) { SoundManager.Instance.PlaySFX(openCloseSFX); }
		}
	}
}