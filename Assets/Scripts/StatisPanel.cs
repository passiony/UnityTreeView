using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatisPanel : MonoBehaviour
{
    public Button m_QuitBtn;
    
    void Start()
    {
        m_QuitBtn.onClick.AddListener(this.OnQuitClick);        
    }

    private void OnQuitClick()
    {
        gameObject.SetActive(false);
    }

}
