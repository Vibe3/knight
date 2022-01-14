using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class passSystem : MonoBehaviour
{
    public string Target = "ÃM¤h";
    public UnityEvent end;

    public GameObject menu;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == Target)
        {
            SceneManager.LoadScene("Sceneone");
        }
    }

    private void Update()
    {
        if (Knight.hp <= 0)
        {
           end.Invoke();
           menu.SetActive(true);
        }
    }
}
