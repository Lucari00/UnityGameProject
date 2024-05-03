using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionToTuto : MonoBehaviour
{
    public void ButtonPressed() {
        SceneManager.LoadScene("TutoScene");
    }
}
    