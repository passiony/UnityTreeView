using System;
using TMPro;
using UnityEngine;

public class DateNow : MonoBehaviour
{
    private TextMeshProUGUI m_Text;

    private void Awake()
    {
        m_Text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        m_Text.text = DateTime.Now.ToString("yyyy.MM.dd");
    }
}
