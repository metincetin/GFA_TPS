using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GFA.TPS
{
	public class Loader : MonoBehaviour
	{
		[SerializeField] private int _sceneToLoadIndex;

		[SerializeField] private Image _progressBar;
		private AsyncOperation _operation;

		private IEnumerator Start()
		{
			yield return new WaitForEndOfFrame();
			_operation = SceneManager.LoadSceneAsync(_sceneToLoadIndex);
		}

		private void Update()
		{
			if (_operation != null)
			{
				_progressBar.fillAmount = _operation.progress;
			}
		}
	}
}