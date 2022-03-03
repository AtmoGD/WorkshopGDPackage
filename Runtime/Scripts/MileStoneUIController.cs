using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MileStoneUIController : MonoBehaviour
{
    [SerializeField] private Text milestoneText;
    [SerializeField] private Character characterController;
    void Start()
    {
        milestoneText = GetComponent<Text>();
        characterController = FindObjectOfType<Character>();
    }

    void Update()
    {
        if(!characterController) return;

        milestoneText.text = characterController.CurrentMileStone.ToString();
    }
}
