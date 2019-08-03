using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ApiClient : MonoBehaviour
{
    const string url = "http://localhost:50287/API/Itens";

    // Use this for initialization
    void Start()
    {
        StartCoroutine(GetItensAPI());
        StartCoroutine(PostItemAPI());
    }

    private IEnumerator PostItemAPI()
    {
        WWWForm form = new WWWForm();

        form.AddField("nome", "ItemFromUnity");
        form.AddField("descricao", "Item enviado pela unity (metodo POST)");
        form.AddField("raridade", "50");
        form.AddField("danoMaximo", "10");
        form.AddField("tipoItemID", "1");

        using (UnityWebRequest request = UnityWebRequest.Post(url + "/Create", form))
        {
            yield return request.SendWebRequest();

            if(request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log("Envio executado com sucesso");
            }
        }
    }

    IEnumerator GetItensAPI()
    {
        //UnityWebRequest request = UnityWebRequest.Get(url + "/1");
        UnityWebRequest request = UnityWebRequest.Get(url);

        //obsoleto 
        //yield return request.Send();

        // novo metodo
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            string strRespostaServidor = request.downloadHandler.text;
            Debug.Log(strRespostaServidor);

            byte[] result = request.downloadHandler.data;

            //Item meuItem = JsonUtility.FromJson<Item>(strRespostaServidor);
            //ImprimirItem(meuItem);

            //*ListaItens listaItensServidor = new ListaItens();
            //*JsonUtility.FromJsonOverwrite(strRespostaServidor, listaItensServidor);

            Item[] teste = JsonHelper.getJsonArray<Item>(strRespostaServidor);

            foreach (Item i in teste)
            {
                ImprimirItem(i);
            }
        }
    }

    void ImprimirItem(Item i)
    {
        Debug.Log("====== Dados objeto ======= ");
        Debug.Log("ID: " + i.ItemID);
        Debug.Log("Nome: " + i.Nome);
        Debug.Log("Força: " + i.Forca);
        Debug.Log("Defesa: " + i.Defesa);
        Debug.Log("Agilidade: " + i.Agilidade);

    }
}
