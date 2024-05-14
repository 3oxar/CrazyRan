using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScene : MonoBehaviour
{
    [SerializeField] private int _openScene;
    [SerializeField] private GameObject _plane;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) OpenPlaneWin();
    }

    /// <summary>
    /// ��������� �����
    /// </summary>
    public void LoadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(_openScene);
    }

    /// <summary>
    /// ��������� �����
    /// </summary>
    /// <param name="openScene">Id �����</param>
    public void LoadScene(int openScene)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(openScene);
    }

    /// <summary>
    /// ��������� ������ ������ 
    /// </summary>
    public void OpenPlaneWin()
    {
        Time.timeScale = 0;
        _plane.SetActive(true);
    }
}
