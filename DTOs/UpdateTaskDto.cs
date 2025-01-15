namespace TaskManager.DTOs
{
    public class UpdateTaskDto
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; } = string.Empty; // Datos que se pueden actualizar
        public int? CategoryId { get; set; } // Solo si es necesario actualizar la categoría
    }
}
