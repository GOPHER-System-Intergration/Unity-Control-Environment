using UnityEngine;

public class Webcam : MonoBehaviour {
    public int deviceId = 0;
    public int inputWidth = 4096;
    public int inputHeight = 2048;
    public RenderTexture outputTexture;
    private WebCamTexture webcamTexture;
    private Texture2D bufferTexture;
    private int xOffset;
    private int yOffset;
    private bool needsBuffer;
	void Start () {
        WebCamDevice[] devices = WebCamTexture.devices;
        webcamTexture = new WebCamTexture(3840,1080);
        bufferTexture = new Texture2D(4096, 2048);
        needsBuffer = !(inputWidth==4096&&inputHeight==2048);
        xOffset = (4096-inputWidth)/2;
        yOffset = (2048-inputHeight)/2;
        webcamTexture.deviceName = devices[deviceId].name;
        
        webcamTexture.Play();
        
    }

    void Update() {
        if (needsBuffer) {
            Graphics.CopyTexture(webcamTexture, 0, 0, 0, 0, inputWidth, inputHeight, bufferTexture, 0, 0, xOffset, yOffset);
            Graphics.Blit(bufferTexture, outputTexture);
        } else {
            Graphics.Blit(webcamTexture, outputTexture);
        }
        
    }
}
