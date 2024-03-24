using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool isHit = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void supprEnemy() {
        gameObject.SetActive(false);
    }

    public void hit() {
        Debug.Log("ici");
        if (!isHit) {
            // faire anim de kill
            Invoke("supprEnemy", 3f);
        }
        isHit = true;
    }
}
