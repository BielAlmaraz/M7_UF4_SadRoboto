using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour

{
	public TextMeshProUGUI CoinText, ThunderText;
	public Image[] items;
	public static GameManager gameManager;
	public int Orbs = 0, Coins = 0;
	public bool reset;

	private void Awake()
	{
		if (GameManager.gameManager != null && GameManager.gameManager != this)
			Destroy(gameObject);

		else
		{
			GameManager.gameManager = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	public void OrbCollected()
	{
		Orbs++;
		ThunderText.text = "Thunders: " + Orbs;
	}

	public void CoinCollected(int i)
	{
		Coins+= i;
		CoinText.text = "Coins: " + Coins;
	}

	public void GetItem(Sprite sprite, int i)
	{
		items[i].sprite = sprite;
	}

	public interface ICollectable
	{
		public void OnCollected();
	}

	public void ItemCollected(Sprite sprite, int id)
	{
		items[id].sprite = sprite;
	}
}