using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MonehScript : MonoBehaviour
{
    public TextMeshProUGUI monehText;

    public void SetMoneh(int moneh)
    {
        monehText.text = "$" + moneh.ToString();
    }
}
