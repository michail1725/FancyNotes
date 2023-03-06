using FancyNotes.Client.Services.Contracts;
using FancyNotes.Shared;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text;
using System.Text.Json;

namespace FancyNotes.Client.Services
{
    public class NoteClientService : INoteClientService
    {
        private readonly HttpClient _httpClient;

        public NoteClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Note> CreateNote(Note note)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<Note>($"api/users", note);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default;
                    }

                    return await response.Content.ReadFromJsonAsync<Note>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task DeleteItem(int noteId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/notes/{noteId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<Note> GetNote(int noteId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/notes/{noteId}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default;
                    }

                    return await response.Content.ReadFromJsonAsync<Note>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<Note>> GetNotesList(int userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/notes/{userId}/GetNoteList");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<Note>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<Note>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Note> UpdateNote(Note note)
        {
            try
            {
                var jsonRequest = JsonSerializer.Serialize(note);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json-patch+json");

                var response = await _httpClient.PatchAsync($"api/notes", content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Note>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            
        }
    }
}
