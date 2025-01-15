namespace TaskManager.DTOs
{
    public class CategoryDto
    {
    
            public int CategoryId { get; set; }         // ID de la categoría
            public string CategoryName { get; set; }   // Nombre de la categoría
            public string? CategoryDescription { get; set; } // Descripción de la categoría
            public int? CategoryPoints { get; set; }   // Puntos asignados a la categoría
            public DateOnly? CategoryDeadLine { get; set; } // Fecha límite de la categoría
        

    }
}
