using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	public GameObject playMenu;
	public GameObject settings;
	public GameObject credits;

	public void PlayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void Settings()
	{
		playMenu.SetActive(false);
		credits.SetActive(false);
		settings.SetActive(true);
	}

	public void PlayMenu()
	{
		playMenu.SetActive(true);
		credits.SetActive(false);
		settings.SetActive(false);
	}

	public void Credits()
	{
		playMenu.SetActive(false);
		credits.SetActive(true);
		settings.SetActive(false);
	}

	public void GoBackToMenu()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
	}
}
