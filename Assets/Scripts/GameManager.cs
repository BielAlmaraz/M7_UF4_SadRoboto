using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour

{
	public TextMeshProUGUI CoinText, ThunderText;
	public Image[] Items;
	public static GameManager gameManager;
	public int Orbs = 0, Coins = 0;

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

	public void CoinCollected()
	{
		Coins++;
		CoinText.text = "Coins: " + Coins;
	}

	public interface ICollectable
	{
		public void OnCollected();
	}

	public void ItemCollected(Sprite sprite, int id)
	{
		Items[id].sprite = sprite;
	}
}