using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSaver : MonoBehaviour
{
	public int ID;
	private void Awake()
	{
		if (PlayerPrefs.HasKey("Coin" + ID) && PlayerPrefs.GetInt("Coin" + ID) == 1)
			LoadCoin();

		if (GameManager.gameManager.reset)
			ResetCoins();
	}

	private void OnTriggerEnter(Collider other)
	{
		PlayerPrefs.SetInt("Coin" + ID, 1);
	}

	public void LoadCoin()
	{
		if (GameManager.gameManager != null)
    		{
        		GameManager.gameManager.CoinCollected(1);
        		gameObject.SetActive(false);
    		}
  		else
    		{
        		Debug.LogError("GameManager no está asignado correctamente");
    		}
	}

	public void ResetCoins()
	{
		if(GameManager.gameManager.reset)
			PlayerPrefs.SetInt("Coin" + ID, 0);
	}
}
