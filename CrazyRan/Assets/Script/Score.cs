using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int coins = 0;

    [SerializeField] private TextMeshProUGUI _textScore;

    [SerializeField] private int _totalCoins;

    private void Start()
    {
        ScoreText();
    }

    /// <summary>
    /// ������� ������� ����� �������� 
    /// </summary>
    public void ScoreText()
    {
        _textScore.text = "�����: " + coins.ToString() + "/" + _totalCoins.ToString();
    }
}
