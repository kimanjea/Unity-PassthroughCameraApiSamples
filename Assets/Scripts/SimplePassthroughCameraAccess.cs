using UnityEngine;
using PassthroughCameraSamples;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class SimplePassthroughCameraAccess : MonoBehaviour
{
    [SerializeField] private WebCamTextureManager webCamTextureManager;
    [SerializeField] private TextMeshProUGUI webCamTextureDebugInfo;
    [SerializeField] private TextMeshProUGUI webCamDeviceDebugInfo;
    [SerializeField] private RawImage webCamImage;

    private IEnumerator Start()
    {
        while(webCamTextureManager.WebCamTexture == null)
        {
            yield return null;
        }

        webCamTextureDebugInfo.text = "WebCamText object is currently running";

        webCamImage.texture = webCamTextureManager.WebCamTexture;

        var cameraEye = webCamTextureManager.Eye;

        var cameraDetails = PassthroughCameraUtils.GetCameraIntrinsics(cameraEye);

        webCamDeviceDebugInfo.text = $"PrincipalPoint: {cameraDetails.PrincipalPoint}"
                                    + $"\nFocalLength: {cameraDetails.FocalLength}"
                                    + $"\nResolution: {cameraDetails.Resolution}"
                                    + $"\nSkew: {cameraDetails.Skew}";

    }
}
