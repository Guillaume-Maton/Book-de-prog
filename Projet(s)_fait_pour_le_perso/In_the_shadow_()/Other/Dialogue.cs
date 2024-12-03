using System.Collections;
using UnityEngine;
using TMPro;
using System.Linq;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    Coroutine typingCoroutine;
    public string[] sentences;
    public int[] BlockedSentences = new int[] {3, 4, 5, 6, 7, 10, 11, 12};
    public int Index;
    public float typingSpeed;

    void Start()
    {
        typingCoroutine = StartCoroutine(Type());
    }

    void Update()
    {

        if (Input.GetKeyUp(KeyCode.C) && !BlockedSentences.Contains(Index))
        {
            NextSentence();
        }

        if (Input.GetKeyUp(KeyCode.Joystick1Button2) && !BlockedSentences.Contains(Index))
        {
            NextSentence();
        }
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[Index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if (typingCoroutine != null)
        StopCoroutine(typingCoroutine);
        if(Index < sentences.Length - 1)
        {
            Index++;
            textDisplay.text = "";
            typingCoroutine = StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
        }
    }
}