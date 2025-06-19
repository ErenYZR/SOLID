using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	public static SceneLoader Instance { get; private set; }


	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad(gameObject);
	}

	public enum SceneType
	{
		MainMenu,
		Level1,
		Level2,
		GameOver
	}

	public void LoadScene(SceneType sceneType)
	{
		string sceneName = GetSceneName(sceneType);
		SceneManager.LoadScene(sceneName);
		Time.timeScale = 1f;
	}

	private string GetSceneName(SceneType sceneType)
	{
		switch (sceneType)
		{
			case SceneType.MainMenu: return "MainMenu";
			case SceneType.Level1: return "Level1";
			case SceneType.Level2: return "Level2";
			case SceneType.GameOver: return "GameOver";
			default:
				Debug.LogError("Scene name not defined for " + sceneType);
				return "";
		}
	}

	public void RestartCurrentScene()
	{
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentSceneIndex);
		Time.timeScale = 1f;
	}
}
