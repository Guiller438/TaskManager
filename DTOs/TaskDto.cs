namespace TaskManager.DTOs
{
    public class TaskDto
    {
        public int TaskId { get; set; }          // ID de la tarea
        public string TaskName { get; set; }    // Nombre de la tarea
        public int? CategoryId { get; set; }    // ID de la categoría asociada
        public string? CategoryName { get; set; } // Nombre de la categoría (opcional para mostrar)
    }
}
