using UnityEngine.Advertisements;
using UnityEngine;

public class AdsManager : 
    MonoBehaviour, 
    IUnityAdsInitializationListener, 
    IUnityAdsLoadListener,
    IUnityAdsShowListener
{
    [SerializeField] private bool testMode = true;
    [SerializeField] private string androidGameId;

    private const string AndroidInterstitialAdUnitId = "Interstitial_Android";
    private const string AndroidRewardedUnitId = "Rewarded_Android";
    
    private string gameId;

    private void Awake()
    {
        this.Initialize();
        Advertisement.Load(this.androidGameId, this);
    }

    //Initialize
    
    private void Initialize()
    {
        Advertisement.Initialize(this.androidGameId, testMode, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
    
    
    //Loaded

    public void OnUnityAdsAdLoaded(string placementId)
    {
        // Optionally execute code if the Ad Unit successfully loads content.
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.LogError($"Error loading Ad Unit: {AdsManager.AndroidRewardedUnitId} - {error.ToString()} - {message}");
        // Optionally execute code if the Ad Unit fails to load, such as attempting to try again.
    }
    
    
    //Show

    public void ShowAd()
    {
        Debug.Log($"Showing Ad: {AdsManager.AndroidInterstitialAdUnitId}");
        Advertisement.Show(AdsManager.AndroidInterstitialAdUnitId, this);
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.LogError($"Error loading Ad Unit: {AdsManager.AndroidInterstitialAdUnitId} - {message}");
        // Optionally execute code if the Ad Unit fails to show, such as loading another ad.
    }

    public void OnUnityAdsShowStart(string placementId) { }
    public void OnUnityAdsShowClick(string placementId) { }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (AdsManager.AndroidInterstitialAdUnitId.Equals(AdsManager.AndroidInterstitialAdUnitId) &&
            showCompletionState.Equals(UnityAdsCompletionState.COMPLETED))
        {
            Debug.Log("Unity Ads Rewarded Ad Complete");
            Advertisement.Load(AdsManager.AndroidInterstitialAdUnitId, this);
        }
    }
}
