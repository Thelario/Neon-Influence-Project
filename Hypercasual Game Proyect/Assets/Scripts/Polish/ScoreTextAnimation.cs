using UnityEngine;
using TMPro;

public class ScoreTextAnimation : MonoBehaviour
{
	public float animationDuration;

	public float angleToRotate;

	private int dirToRotate;

	void Start()
	{
		GameManager.Instance.onScoreIncremented.AddListener(MakeTweenScalingAnimation);
	}

	public void MakeTweenScalingAnimation()
	{
		int dirToRotate = Random.Range(0, 2);

		LeanTween.scale(gameObject, new Vector3(1.5f, 1.5f, 1.5f), animationDuration).setOnComplete(MakeDeScaling);

		if (dirToRotate == 0)
			LeanTween.rotateZ(gameObject, angleToRotate, animationDuration);
		else if (dirToRotate == 1)
			LeanTween.rotateZ(gameObject, -angleToRotate, animationDuration);
	}

	public void MakeDeScaling()
	{
		LeanTween.scale(gameObject, new Vector3(1f, 1f, 1f), animationDuration);
		LeanTween.rotateZ(gameObject, 0f, animationDuration);
	}
}
