// Copyright (C) 2018-2022 gamevanilla. All rights reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement,
// a copy of which is available at http://unity3d.com/company/legal/as_terms.

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BubbleShooterKit
{
	/// <summary>
	/// This class manages the high-level logic of the home screen.
	/// </summary>
	public class HomeScreen : BaseScreen
	{

#pragma warning disable 649
		[SerializeField]
		private GameObject bgMusicPrefab;

		[SerializeField]
		private GameObject playButton;
		[SerializeField] private GameObject loading;

		[SerializeField]
		private GameObject purchaseManagerPrefab;

#pragma warning restore 649


        private void Awake()
        {
			playButton.SetActive(false);
			loading.SetActive(true);
        }
		private IEnumerator DisplayBanner() {
			yield return new WaitForSeconds(1);
            AdsManager.Instance.bannerAds.ShowBannerAd();
            yield return new WaitForSeconds(3);
            playButton.SetActive(true);
            loading.SetActive(false);
        }

        protected override void Start()
		{
			base.Start();
			
			var bgMusic = FindObjectOfType<BackgroundMusic>();
			if (bgMusic == null)
				Instantiate(bgMusicPrefab);

            StartCoroutine(DisplayBanner());

#if BUBBLE_SHOOTER_ENABLE_IAP
			var purchaseManager = FindObjectOfType<PurchaseManager>();
			if (purchaseManager == null)
				Instantiate(purchaseManagerPrefab);
#endif
        }


        public void OnSettingsButtonPressed()
        {
            OpenPopup<SettingsPopup>("Popups/SettingsPopup");
        }
	}
}
