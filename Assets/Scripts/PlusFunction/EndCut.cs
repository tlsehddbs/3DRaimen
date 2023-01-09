using System.Collections;
using TMPro;
using UnityEngine; 
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class EndCut : MonoBehaviour 
{ 
    public TextMeshProUGUI m_TypingText; 
    public string[]  m_Message;     
    public float m_Speed = 0.2f;

    private int count = 0;

    void Start() 
    {
        m_TypingText.text = "";
        StartCoroutine(Typing(m_TypingText, m_Message, m_Speed)); 
    } 

    IEnumerator Typing(TextMeshProUGUI typingText, string[] message, float speed) 
    {
        for (int j = 0; j < m_Message.Length; j++)
        {
            for (int i = 0; i < message[j].Length; i++) 
            { 
                typingText.text = message[j].Substring(0, i + 1); 
                yield return new WaitForSeconds(speed); 
            }
            yield return new WaitForSeconds(2);
        }
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Titlee");
    } 
}