using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{
	public UnityEvent onScoreIncremented;

	public static GameManager Instance { get; private set; }

	public Text scoreText;
	public int score;

	public GameObject floatingScoreTextPrefab;
	public Transform worldCanvas;

	private void Awake()
	{
		Instance = this;
	}

	void Start()
	{
		score = 0;
		scoreText.text = "" + score;
		scoreText.gameObject.SetActive(true);

		Player.PlayerDead += OnPlayerDeath;
	}
	
	public void UpdateScoreText(int score, Vector2 positionToSpawnFloatingScoreText)
	{
		this.score += score;
		scoreText.text = "" + this.score;

		GameObject scoreFloatingText = Instantiate(floatingScoreTextPrefab, positionToSpawnFloatingScoreText, Quaternion.identity, worldCanvas);
		scoreFloatingText.GetComponent<TMP_Text>().text = "" + score;

		onScoreIncremented.Invoke();
	}

	public void OnPlayerDeath()
	{
		scoreText.gameObject.SetActive(false);
	}

	private void OnDestroy()
	{
		Player.PlayerDead -= OnPlayerDeath;
	}
}
