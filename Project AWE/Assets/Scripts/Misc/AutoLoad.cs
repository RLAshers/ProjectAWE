using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoLoad : MonoBehaviour {
    public int LevelByInt = -1;
    public string LevelByString = "";

    // Use this for initialization
    void Start () {
        if ((LevelByInt != -1) && (LevelByInt < SceneManager.sceneCountInBuildSettings))
        {
            SceneManager.LoadScene(LevelByInt);
        }

        if (LevelByString != "")
        {
            if (SceneManager.GetSceneByName(LevelByString) != null)
            {
                SceneManager.LoadScene(LevelByString);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
