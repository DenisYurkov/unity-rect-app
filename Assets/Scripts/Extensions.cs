using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

public static class Extensions
{
    private static CancellationTokenSource _cancellationTokenSource;
    public static async Task<string> GetContentFromServer(string path, int id)
    {
        _cancellationTokenSource = new CancellationTokenSource();
        CancellationToken cancellationToken = _cancellationTokenSource.Token;
        Debug.Log("Create Token!");
        
        using HttpClient httpClient = new HttpClient();
        HttpResponseMessage response = await httpClient.GetAsync(path + id, cancellationToken);
        
        try
        {
            return await Task.Run(() =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                return response.Content.ReadAsStringAsync();
            }, cancellationToken);
        }
        catch (Exception e)
        {
            Debug.Log($"Catched Exception: {e}");
            throw;
        }
        finally
        {
           CancelToken();
        }
    }

    public static async Task<byte[]> GetContentFromServerByte(string path)
    {
        _cancellationTokenSource = new CancellationTokenSource();
        CancellationToken cancellationToken = _cancellationTokenSource.Token;
        Debug.Log("Create Token!");
        
        using HttpClient httpClient = new HttpClient();
        HttpResponseMessage response = await httpClient.GetAsync(path, cancellationToken);
        
        try
        {
            return await Task.Run(() =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                return response.Content.ReadAsByteArrayAsync();
            }, cancellationToken);
        }
        catch (Exception e)
        {
            Debug.Log($"Catched Exception: {e}");
            throw;
        }
        finally
        {
            CancelToken();
        }
    }

    public static T Deserialize<T>(string json) => JsonConvert.DeserializeObject<T>(json);

    public static void CancelToken()
    {
        _cancellationTokenSource?.Cancel();
        _cancellationTokenSource?.Dispose();
        _cancellationTokenSource = null;
        Debug.Log("Delete Token!"); 
    }
}