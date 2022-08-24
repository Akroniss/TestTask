using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text _counter;
    [SerializeField] private Text _gameOver;
    [SerializeField] private Text _gameStart;
    private int _count = 0;
    private void Start()
    {
        Block.DealingDamage += Counter;
        Player.GameOver += GameOver;
        Player.Play += Play;
    }
    private void Counter(int damage)
    {
        _count += damage;
        _counter.text = _count.ToString();
    }
    private void GameOver(Player player)
    {
        _gameOver.gameObject.SetActive(true);
    }
    private void Play(Player player)
    {
        _gameStart.gameObject.SetActive(false);
        _counter.gameObject.SetActive(true);
        Player.Play -= Play;
    }
}
