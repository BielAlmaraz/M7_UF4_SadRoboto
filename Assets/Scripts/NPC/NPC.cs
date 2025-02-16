using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class NPC : MonoBehaviour
{
	public CinemachineVirtualCamera VCamDisable;
	public CinemachineVirtualCamera VCamEnable;
	public GameObject UI;
	private PlayerMover _playerMover;
	private bool _canBuy = true;
	private float time = 1f;
	public GameObject HUD;

	private void OnTriggerEnter(Collider other)
	{
		if(_canBuy)
		{
			VCamDisable.GetComponent<CinemachineVirtualCamera>().enabled = false;
            VCamEnable.GetComponent<CinemachineVirtualCamera>().enabled = true;
            Camera.main.GetComponent<CinemachineBrain>().enabled = true;
			Camera.main.cullingMask &= ~(1 << 8);
            _playerMover = other.GetComponent<PlayerMover>();
			Debug.Log(other.gameObject.name);
            if (_playerMover == null)
            {
                Debug.LogError("PlayerMover component is missing on: " + other.gameObject.name);
            }
            else
            {
                _playerMover.canMove = false;
            }
            UI.SetActive(true);
			HUD.SetActive(false);
			_canBuy = false;
		}
	}
	
	private void OntriggerExit(Collider other)
	{
		StartCoroutine(WaitForABit());
	}

	public void ExitStore()
	{
        if (_playerMover == null)
        {
            Debug.LogError("hol");
        }
        else
        {
            _playerMover.canMove = true;
        }
        VCamDisable.GetComponent<CinemachineVirtualCamera>().enabled = false;
        VCamEnable.GetComponent<CinemachineVirtualCamera>().enabled = true;
        Camera.main.GetComponent<CinemachineBrain>().enabled = false;
		Camera.main.cullingMask |= (1 << 8);
		HUD.SetActive(true);
		UI.SetActive(false);
	}
	
	private IEnumerator WaitForABit()
	{
		yield return new WaitForSeconds(time);
		_canBuy = true;
	}
}
