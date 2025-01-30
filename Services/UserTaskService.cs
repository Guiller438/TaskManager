using TaskManager.Models;
using TaskManager.Repositories;

namespace TaskManager.Services
{
    public class UserTaskService: ITaskUserService
    {
        private readonly HttpClient _httpClient;
        public UserTaskService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<bool> AssignTaskToUserAsync(int taskId)
        {
            try
            {
                var response = await _httpClient.PostAsync($"TaskUsers/AsignarTareas?TaskId={taskId}", null);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    // Registrar el error si es necesario
                    Console.WriteLine($"Error al asignar tarea: {response.StatusCode}");
                    return false;
                }
            }
            catch (HttpRequestException ex)
            {
                // Manejo de errores de red
                Console.WriteLine($"Error de red al asignar tarea: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteTaskAsync(int taskId)
        {
            var response = await _httpClient.DeleteAsync($"TaskUsers/DeleteTask?TaskId={taskId}");

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            return true;
        }
    }
}
