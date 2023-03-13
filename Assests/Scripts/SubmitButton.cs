
using UnityEngine;
using UnityEngine.UI;

public class SubmitButton : MonoBehaviour
{
    [SerializeField] private InputField nameField;
    [SerializeField]
    private string sceneName;
    public static string PlayerName;

    private void Start()
    {
        PlayerName = string.Empty;
    }


    public void PressButtonSubmit()
    {
        if (nameField.text == string.Empty)
            return;
        PlayerName = nameField.text;
        GetComponent<SceneLoader>().LoadScene(sceneName);
    }
}
