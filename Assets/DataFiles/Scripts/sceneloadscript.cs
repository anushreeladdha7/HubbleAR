using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneloadscript : MonoBehaviour {
	public void sceneloader(string name){
		SceneManager.LoadScene(name);
	}

}
