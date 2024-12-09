using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbScript : MonoBehaviour, ICollectable
{
	public void OnCollected()
	{
		GameManager.gameManager.OrbCollected();
		Destroy(gameObject);
	}
}
