using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    private Vector3 respawnPosition;
    public Transform respawnPoint;


    private void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        respawnPosition = respawnPoint.position;
    }

    void Update()
    {
        
    }
    public void Respawn()
    {
        PlayerController.instance.gameObject.SetActive(false);
        HealthManager.instance.ResetHealth();
        PlayerController.instance.ResetMovement();
        PlayerController.instance.transform.position = respawnPosition;
        PlayerController.instance.gameObject.SetActive(true);
    }
}
