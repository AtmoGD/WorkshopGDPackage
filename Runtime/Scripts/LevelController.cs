using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private string nextLevel;
    [SerializeField] private float speed = 2f;
    public bool IsActive { get; set; }

    void Start()
    {
        IsActive = true;
    }
    
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        
        if(!IsActive) return;

        Move();
    }

    private void Move()
    {
        Vector2 dir = Vector2.left * speed * Time.deltaTime;
        transform.Translate(dir);
    }

    public string GetNextLevel()
    {
        return nextLevel;
    }
}
