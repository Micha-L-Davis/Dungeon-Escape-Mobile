using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    [SerializeField]
    Button _adButton;
    [SerializeField]
    Player _player;
    [SerializeField]
    int _rewardValue = 100;
    string _gameId = "4160541";
    public string pID = "Rewarded_Android";


    void Start()
    {
        _adButton.interactable = Advertisement.IsReady(pID);
        Advertisement.AddListener(this);
        Advertisement.Initialize(_gameId, true);
    }

    void ShowRewardedAd()
    {
        Advertisement.Show(pID);
    }

       public void OnUnityAdsReady(string placementId)
    {
        if (placementId == pID)
        {
            _adButton.interactable = true;
        }
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Failed:
                Debug.LogError("Ad error. Try again.");
                break;
            case ShowResult.Skipped:
                Debug.LogError("Ad skipped. No reward issued.");
                break;
            case ShowResult.Finished:
                _player.LootGain(_rewardValue);
                break;
            default:
                break;
        }
    }

 public void OnUnityAdsDidError(string message)
    {
        Debug.LogError("Ad error. Try again.");
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //not implemented
    }


}
