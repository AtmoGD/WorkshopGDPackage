using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Character characterController;
    public bool IsActive { get; set; }

    void Start()
    {
        characterController = FindObjectOfType<Character>();
    }

    void Update()
    {
        if(!characterController && IsActive) return;
        
        Vector2 newPos = transform.position;
        newPos.x = characterController.transform.position.x;
    }
}
