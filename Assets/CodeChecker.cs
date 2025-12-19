using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CodeChecker : MonoBehaviour
{
    [Serializable]
    public class Level
    {
        public GameObject VisibleObject;
        public string Code;
        public bool SharpImage = false;
    }
    [SerializeField]
    TMP_InputField inputField;

    [SerializeField]
    Button confirmButton;
    [SerializeField]
    TextMeshProUGUI messageText, enterText;
    private Coroutine hideMessageCoroutine;

    public Level[] Levels;
    int currentLevel;
    void Awake()
    {
        confirmButton.onClick.AddListener(() =>
        {
            if (inputField.text == Levels[currentLevel].Code)
            {
                ShowMessage("Correct!");
                NextLevel();
            }
            else
            {
                ShowMessage("Wrong code");
            }
        });
    }
    private void NextLevel()
    {
        Levels[currentLevel].VisibleObject.SetActive(false);
        currentLevel++;
        if (currentLevel >= Levels.Length)
        {
            ShowMessage("Thanks for playing!", 5);
            enterText.gameObject.SetActive(false);
            confirmButton.gameObject.SetActive(false);
            inputField.gameObject.SetActive(false);

            return;
        }
        Levels[currentLevel].VisibleObject.SetActive(true);
        BackgroundSelector.Instance.SetImage(Levels[currentLevel].SharpImage);


    }
    private void ShowMessage(string message, float delay = 2)
    {
        messageText.gameObject.SetActive(true);
        messageText.text = message;
        if (hideMessageCoroutine != null)
        {
            StopCoroutine(hideMessageCoroutine);

        }
        hideMessageCoroutine = StartCoroutine(HideMessageCoroutine(delay));
    }
    IEnumerator HideMessageCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        messageText.gameObject.SetActive(false);


    }
}
