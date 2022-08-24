using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text _counter;
    [SerializeField] private Text _gameOver;
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
        player.GetComponent<Movement>().enabled = false;
        player.GetComponent<Attack>().enabled = false;
        _gameOver.gameObject.SetActive(true);
    }
    private void Play(Player player)
    {
        player.GetComponent<Movement>().enabled = true;
        player.GetComponent<Attack>().enabled = true;
        Player.Play -= Play;
    }
}
