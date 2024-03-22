using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGarageDoors : MonoBehaviour
{

    private float doorSpeed = 0.00001f;
    private float doorOpenHeight = 5f;
    // Start is called before the first frame update
    void Start()
    {
        while(transform.position.y < doorOpenHeight) {
            Invoke("OpenDoors", 0.1f);
        }
    }

    private void OpenDoors() {
        transform.position = new Vector3(transform.position.x, transform.position.y + doorSpeed * Time.deltaTime, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        /*while(transform.position.y < doorOpenHeight) {
            transform.position = new Vector3(transform.position.x, transform.position.y + doorSpeed * Time.deltaTime, transform.position.z);
        }*/
    }
}
