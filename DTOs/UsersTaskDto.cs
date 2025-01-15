public class UsersTaskDto
{
    public int UserTaskId { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; } // Opcional para mostrar el nombre del usuario
    public int TaskId { get; set; }
    public string TaskName { get; set; } // Opcional para mostrar el nombre de la tarea
    public bool? StatusTask { get; set; }
    public string? EvidencePath { get; set; }
    public DateTime? EvidenceUploadDate { get; set; }
}
