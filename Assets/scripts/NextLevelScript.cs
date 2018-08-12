using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScript : MonoBehaviour {

	public string myScene;

    void LoadScene()
    {
        //Scene loadedLevel = SceneManager.GetActiveScene();
		SceneManager.LoadScene (myScene);
    }

    private void OnTriggerEnter(Collider other)
    {
        LoadScene();
    }
}
