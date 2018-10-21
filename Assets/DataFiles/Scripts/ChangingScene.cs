using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangingScene : MonoBehaviour {

	public void explore()
	{
		SceneManager.LoadScene("ARLearning");
	}
	public void playgame()
	{
		SceneManager.LoadScene("Quiz");
	}
	public void discussion()
	{
		SceneManager.LoadScene("Discussion");
	}

}
