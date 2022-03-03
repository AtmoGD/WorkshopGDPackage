using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void Collect() {
        animator.SetTrigger("Collect");
        GetComponent<AudioSource>().Play();
    }
}
