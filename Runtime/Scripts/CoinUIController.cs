using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinUIController : MonoBehaviour
{
    [SerializeField] private Text coinText;
    [SerializeField] private Character characterController;
    void Start()
    {
        coinText = GetComponent<Text>();
        characterController = FindObjectOfType<Character>();
    }

    void Update()
    {
        if(!characterController) return;

        coinText.text = characterController.CurrentCoins.ToString();
    }
}
