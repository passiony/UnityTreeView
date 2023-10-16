using System;
using TMPro;
using UnityEngine;

public class TimeNow : MonoBehaviour
{
    private TextMeshProUGUI m_Text;

    private void Awake()
    {
        m_Text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        m_Text.text = DateTime.Now.ToString("t");
    }
}
