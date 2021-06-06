using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_MenuBehaviour : MonoBehaviour
{
	public GameObject settingsPanel;
	public GameObject initialMenuPanel;
	public GameObject shopPanel;
	public GameObject informationPanel;
	public GameObject aboutMePanel;
	public GameObject creditsPanel;

	public Slider mbgSlider;
	public Slider sfxSlider;

	private void Start()
	{
		ReportSliderValues();
	}

	public void QuitButton()
	{
		Application.Quit();
	}

	public void OptionsButton()
	{
		ActivateDeactivatePanels(true, false, false, false, false, false);
	}

	public void InitialMenuPanelButton()
	{
		ActivateDeactivatePanels(false, true, false, false, false, false);
	}

	public void ShopPanelButton()
	{
		ActivateDeactivatePanels(false, false, true, false, false, false);
	}

	public void InformationPanelButton()
	{
		ActivateDeactivatePanels(false, false, false, true, false, false);
	}

	public void AboutMePanelButton()
	{
		ActivateDeactivatePanels(false, false, false, false, true, false);
	}

	public void CreditsPanelButton()
	{
		ActivateDeactivatePanels(false, false, false, false, false, true);
	}

	public void ActivateDeactivatePanels(bool optionsPanelActivate, bool initialMenuPanelActivate, bool shopPanelActivate, bool informationPanelActivate, bool aboutMePanelActivate, bool creditsPanelActivate)
	{
		settingsPanel.SetActive(optionsPanelActivate);
		initialMenuPanel.SetActive(initialMenuPanelActivate);
		shopPanel.SetActive(shopPanelActivate);
		informationPanel.SetActive(informationPanelActivate);
		aboutMePanel.SetActive(aboutMePanelActivate);
		creditsPanel.SetActive(creditsPanelActivate);
	}

	public void StartGame()
	{
		DoNotDestroy.previousBackgroundVolume = mbgSlider.value;
		DoNotDestroy.previousSoundEffectsVolume = sfxSlider.value;

		SceneManager.LoadScene(1);
	}

	public void ReportSliderValues()
	{
		mbgSlider.SetValueWithoutNotify(DoNotDestroy.previousBackgroundVolume);
		sfxSlider.SetValueWithoutNotify(DoNotDestroy.previousSoundEffectsVolume);
	}
}
