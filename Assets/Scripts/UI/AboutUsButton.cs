using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AboutUsButton : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(RunScene);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(RunScene);
    }

    private void RunScene()
    {
        SceneManager.LoadScene("AboutUs");
    }
}
