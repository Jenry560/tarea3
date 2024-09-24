
using System.Text.Json;
using Microsoft.JSInterop;
using Tarea3.models;

public class AccidenteService
{
    private readonly IJSRuntime _js;

    public AccidenteService(IJSRuntime js)
    {
        _js = js;
    }

    public async Task<bool> SaveData(Accidente accidente)
    {
        try
        {


            var accidentes = await LoadData();
            if (accidentes == null)
            {
                accidentes = new List<Accidente>();
            }
            // Editar
            if (accidente.Id != 0)
            {
                accidentes = accidentes.Select(a =>
                {
                    if (a.Id == accidente.Id)
                    {
                        return accidente;
                    }
                    return a;
                }
                ).ToList();
            }
            else
            {
                // Nuevo
                accidente.Id = accidentes.Count + 1;
                accidentes.Add(accidente);
            }
            var accidentesJson = JsonSerializer.Serialize(accidentes);
            await _js.InvokeVoidAsync("localStorageHelper.setItem", "data_accidente", accidentesJson);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }

    }

    public async Task<List<Accidente>> LoadData()
    {
        var value = await _js.InvokeAsync<string>("localStorageHelper.getItem", "data_accidente");
        if (!string.IsNullOrEmpty(value))
        {
            try
            {
                var accidentes = JsonSerializer.Deserialize<List<Accidente>>(value);
                if (accidentes == null) return new List<Accidente>();
                return accidentes;
            }
            catch (JsonException ex)
            {
                // Manejar la excepción si es necesario
                Console.WriteLine($"Error deserializando: {ex.Message}");
            }
        }
        return new List<Accidente>();
    }

    public async Task<bool> RemoveData(int id)
    {

        try
        {
            var accidentes = await LoadData();
            if (accidentes == null) return false;
            var accidentesFilter = accidentes.Where(x => x.Id != id).ToList();
            var accidentesJson = JsonSerializer.Serialize(accidentesFilter);
            await _js.InvokeVoidAsync("localStorageHelper.setItem", "data_accidente", accidentesJson);

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }


    public async Task<Accidente?> GetAccidenteById(int id)
    {

        try
        {
            var accidentes = await LoadData();
            if (accidentes == null) return null;
            var accidente = accidentes.Where(x => x.Id == id).FirstOrDefault();

            if (accidente == null) return null;
            return accidente;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return null;
        }
    }
}