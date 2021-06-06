using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class UI_InGameBehaviour : MonoBehaviour
{
	public GameObject pauseGamePanel;
	public GameObject deadGamePanel;

	public TMP_Text scoreTextInDeadPanel;

	public Player player;

	private void Start() { Player.PlayerDead += EnableGameDeadPanel; }

	public void GoToMenuScene()
	{
		SceneManager.LoadScene(0);
		Time.timeScale = 1f;
	}

	public void ResumeGame()
	{
		Time.timeScale = 1f;
		pauseGamePanel.SetActive(false);
	}

	public void PauseGame()
	{
		player.GamePaused();
		pauseGamePanel.SetActive(true);
		Time.timeScale = 0f;
	}

	public void EnableGameDeadPanel()
	{
		scoreTextInDeadPanel.text = GameManager.Instance.score.ToString();

		
		StartCoroutine(WaitRealTime(1f));
	}

	public void RestartGame()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(1);
	}

	public void WatchAdd()
	{

	}

	public void QuitButton() { Application.Quit(); }

	public IEnumerator WaitRealTime(float seconds)
	{
		Time.timeScale = 0.1f;
		yield return new WaitForSecondsRealtime(seconds);
		Time.timeScale = 0f;

		player.GamePaused();
		deadGamePanel.SetActive(true);
	}

	private void OnDestroy() { Player.PlayerDead -= EnableGameDeadPanel; }
}
