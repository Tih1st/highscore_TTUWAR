 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {

	public void Sceneloader(string SceneName)
	{
		//Put scene here
		SceneManager.LoadScene (sceneName: SceneName);
	}
}
