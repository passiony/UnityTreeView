using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MenuPanel : MonoBehaviour
{
    private TreeView m_TreeView;

    [SerializeField] private Image m_Image;
    [SerializeField] private TextMeshProUGUI m_Title;
    [SerializeField] private TextMeshProUGUI m_Content;
    [SerializeField] private VideoPlayer m_VideoPlayer;
    [SerializeField] private Button m_StartBtn;
    [SerializeField] private Button m_BackBtn;
    [SerializeField] private TextAsset m_JsonAsset;

    private SubData m_SubData;
    void Awake()
    {
        var json = m_JsonAsset.text;
        m_TreeView = gameObject.GetComponentInChildren<TreeView>();
        m_TreeView.InitFromJson(json);
        m_TreeView.OnSubBtnClick.AddListener(this.OnSubClick);
        m_StartBtn.onClick.AddListener(this.OnStartClick);
        m_BackBtn.onClick.AddListener(this.OnQuitApp);
    }

    private void OnQuitApp()
    {
        Application.Quit();
    }

    private void OnSubClick(SubData data)
    {
        m_SubData = data;
        m_Title.text = data.Title;
        m_Content.text = data.Content;
        if (!string.IsNullOrEmpty(data.Logo))
        {
            m_Image.sprite = Resources.Load<Sprite>(data.Logo);
        }
        
        var active = !string.IsNullOrEmpty(data.Content);
        m_StartBtn.gameObject.SetActive(active);
        m_Image.gameObject.SetActive(active);
        
        m_VideoPlayer.Stop();
        m_VideoPlayer.gameObject.SetActive(false);
    }
    
    private void OnStartClick()
    {
        if(!string.IsNullOrEmpty(m_SubData.Url))
        {
            if (m_SubData.Url == "Video")
            {
                m_VideoPlayer.gameObject.SetActive(true);
            }
            else
            {
                Process.Start(m_SubData.Url);
            }
        }
    }
}