using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private string GAME_SCENE = "GameScene";

    [SerializeField]
    private GameObject player;

    public void PlayGame()
    {
        string selectedCharacter =
            UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        GameManager.instance.NameCharacter = selectedCharacter;

        SceneManager.LoadScene(GAME_SCENE);

        Debug.Log("Thissdsadsadsa" + player.activeSelf + player.activeInHierarchy);


    }
}
