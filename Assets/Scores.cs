using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scores : MonoBehaviour
{
	public static Scores instance;
	
    public GameObject gameManager;

	public int total_civs = 0;
	public int total_civ_crowds = 0;

	public int saved_Civilians = 0;
	public int saved_Crowds = 0;

	private void Awake()
	{
		if (instance == null) instance = this;
		else
		{
			Destroy(gameObject);
			return;
		}
		DontDestroyOnLoad(gameObject);
	}

	void Update()
    {


		try
		{
			total_civs = GameManager.total_civs;
			total_civ_crowds = GameManager.total_civ_crowds;

			saved_Civilians = GameManager.saved_Civilians;
			saved_Crowds = GameManager.saved_Crowds;
		}
		catch (System.Exception)
		{
			throw;
		}
    }
}

public class Options : MonoBehaviour
{
	public static Options instance;

	public float Volume;

	private void Awake()
	{
		if (instance == null) instance = this;
		else
		{
			Destroy(gameObject); 
			return;
		}
	}
}