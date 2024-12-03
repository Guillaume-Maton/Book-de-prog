using System.Collections;
using UnityEngine;
using TMPro;
using System.Linq;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    Coroutine typingCoroutine;
    public string[] sentences;
    public int[] BlockedSentences = new int[] { 3, 4, 5, 6, 7, 10, 11, 12, 13};
    private int index;
    public float typingSpeed;

    void Start()
    {
        typingCoroutine = StartCoroutine(Type());
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.JoystickButton1) && !BlockedSentences.Contains(index))
        {
            NextSentence();
        }

        if (Input.GetKeyUp(KeyCode.C) && !BlockedSentences.Contains(index))
        {
            NextSentence();
        }
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if(typingCoroutine != null)
        StopCoroutine(typingCoroutine);
        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            typingCoroutine = StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
        }
    }
}
