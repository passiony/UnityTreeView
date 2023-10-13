using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{
    public GameObject m_Image1;
    public GameObject m_Image2;

    public Button m_NextBtn;

    void Start()
    {
        m_NextBtn.onClick.AddListener(this.OnNextClick);
    }

    private void OnNextClick()
    {
        m_Image1.SetActive(!m_Image1.activeSelf);
        m_Image2.SetActive(!m_Image2.activeSelf);
    }

}