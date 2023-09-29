using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SubButton : MonoBehaviour
{
    private TextMeshProUGUI m_Title;
    private Button m_Button;
    private string m_Name;
    private SubData m_Data;
    private UnityEvent<SubData> m_Callback;
    
    private void Awake()
    {
        m_Title = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        m_Button = gameObject.GetComponent<Button>();
        m_Button.onClick.AddListener(this.OnClick);
    }

    public void InitData(string name,SubData data, UnityEvent<SubData> callback)
    {
        m_Name = name;
        m_Data = data;
        m_Title.text = m_Data.Title;
        m_Callback = callback;
    }
    
    private void OnClick()
    {
        m_Callback?.Invoke(this.m_Data);
    }
}
