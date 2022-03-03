using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource clickSource;

    public void StartLevel()
    {
        Character characterController = FindObjectOfType<Character>();
        characterController.HoldHeight = false;
        characterController.Jump();
    }

    public void EndLevel()
    {
        animator.SetTrigger("EndLevel");
    }

    public void ReloadSceneAnim()
    {
        animator.SetTrigger("StartLevel");
        clickSource.Play();
    }

    public void NextLevel()
    {
        animator.SetTrigger("NextLevel");
        clickSource.Play();
    }
}
