using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isHit = false;
    // Start is called before the first frame update
    void Update()
    {
        
    }

    void supprEnemy() {
        gameObject.SetActive(false);
    }

    public void Hit() {
        if (!isHit) {
            // faire anim de kill
            Invoke("supprEnemy", 15f);
        }
        isHit = true;
    }
}
