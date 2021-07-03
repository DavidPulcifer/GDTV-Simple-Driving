using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float accelerationPerSecond = 0.1f;
    [SerializeField] float turnSpeed = 200f;

    int steerValue;
    
    void Update()
    {
        transform.Rotate(0f, steerValue * turnSpeed * Time.deltaTime, 0f);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        speed += accelerationPerSecond * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Obstacle")) 
        {
            SceneManager.LoadScene(0);
        }
    }

    public void Steer(int value)
    {
        steerValue = value;
    }
}
