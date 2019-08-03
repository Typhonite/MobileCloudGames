using System.Collections;
using System.IO;
using UnityEngine;

public class Webcam : MonoBehaviour
{
    WebCamTexture imagemWebCam;

    // Use this for initialization
    void Start ()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        for (int i = 0; i < devices.Length; i++)
            Debug.Log(devices[i].name);

        imagemWebCam = new WebCamTexture();

        GetComponent<MeshRenderer>().material.mainTexture = imagemWebCam;

        imagemWebCam.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(CaptureTextureAsPNG());
        }
    }


    IEnumerator CaptureTextureAsPNG()
    {
        Debug.Log("Apertou");
        yield return new WaitForEndOfFrame();

        try
        {
            Debug.Log("Capturando Tela");
            Texture2D _TextureFromCamera =
                new Texture2D(
                    GetComponent<Renderer>().material.mainTexture.width,
                    GetComponent<Renderer>().material.mainTexture.height
                    );
            _TextureFromCamera.SetPixels(
                (GetComponent<Renderer>().material.mainTexture as WebCamTexture).GetPixels());
            _TextureFromCamera.Apply();
            byte[] bytes = _TextureFromCamera.EncodeToPNG();
            string filePath = "Foto.png";

            File.WriteAllBytes(filePath, bytes);
            Debug.Log("Arquivo escrito");
        }
        catch (System.Exception ex)
        {

            Debug.LogWarning(ex.Message);
        }
    }



}
