using UnityEngine;

public class ScoreFloatingText : MonoBehaviour
{
	private void Start()
	{
		LeanTween.scale(gameObject, new Vector3(0.5f, 0.5f, 0.5f), 0.75f);
		LeanTween.scale(gameObject, new Vector3(0f, 0f, 0f), 0.25f).setOnComplete(DestroyMySelf);
		LeanTween.moveLocalY(gameObject, 1f, 1f);
	}

	private void DestroyMySelf()
	{
		Destroy(gameObject);
	}
}
