using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneStart : MonoBehaviour
{
    private void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }
    void OnClick()
    {
        SceneManager.LoadScene("Sceneone");
    }



    private void Update()
    {
        
    }

}
