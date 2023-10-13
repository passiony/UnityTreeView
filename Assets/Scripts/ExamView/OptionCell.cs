using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionCell : MonoBehaviour
{
    public Toggle m_Toggle;
    public TextMeshProUGUI m_Text;
    public Image m_Image;
    public Image m_Right;
    public Image m_Fault;

    public void InitData(string menu, string imgUrl)
    {
        m_Text.text = menu;
        m_Image.sprite = Resources.Load<Sprite>("Images/" + imgUrl);
        m_Toggle.isOn = false;

        m_Right.gameObject.SetActive(false);
        m_Fault.gameObject.SetActive(false);
    }

    public void ShowError()
    {
        m_Fault.gameObject.SetActive(true);
    }

    public void ShowRight()
    {
        m_Right.gameObject.SetActive(true);
    }
}