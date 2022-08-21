using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] characters;

    public static GameManager instance;

    private string _nameCharacter;

    public string NameCharacter
    {
        get { return _nameCharacter;  }
        set { _nameCharacter = value; }
    }

    private void Awake()
    {
        if (!instance) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
        if(scene.name == "GameScene")
        {
            int characterIndex = NameCharacter == "Player 1" ? 0 : 1;
            Debug.Log(characterIndex);
            Instantiate(characters[characterIndex]);
        }
    }
}
