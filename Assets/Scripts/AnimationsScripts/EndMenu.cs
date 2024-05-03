using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private GameObject endMenu;
    private float timeToDisplayMenu = 5f;

    private void DisplayMenu() {
        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;
        endMenu.SetActive(true);
        Invoke("LoadMainScene", timeToDisplayMenu);
    }

    private void LoadMainScene() {
        SceneManager.LoadScene("HeistScene");
    }
}
