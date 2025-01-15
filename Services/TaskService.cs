﻿using TaskManager.DTOs;
using TaskManager.Models;
using TaskManager.Repositories;

namespace TaskManager.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TaskDto>> GetAllAsync()
        {
            // Obtén las tareas desde el repositorio
            var tasks = await _repository.GetAllAsync();

            // Realiza el mapeo de TfaTask a TaskDto
            var taskDtos = tasks.Select(task => new TaskDto
            {
                TaskId = task.TaskId,
                TaskName = task.TaskName,
                CategoryId = task.CategoryId,
                CategoryName = task.Category?.CategoryName // Asegúrate de que CategoryName sea null-safe
            });

            return taskDtos; // Devuelve el IEnumerable<TaskDto>
        }

        public async Task<TaskDto?> GetByIdAsync(int id)
        {
            // Llama al repositorio para obtener la tarea por ID
            var task = await _repository.GetByIdAsync(id);

            if (task == null)
            {
                return null; // Si no se encuentra la tarea, retorna null
            }

            // Mapea la tarea al DTO
            return new TaskDto
            {
                TaskId = task.TaskId,
                TaskName = task.TaskName,
                CategoryId = task.CategoryId,
                CategoryName = task.Category?.CategoryName // Maneja el caso de que Category sea null
            };
        }

        public async Task AddAsync(TfaTask entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(int id, UpdateTaskDto entity)
        {
            // Busca la tarea existente
            var existingTask = await _repository.GetByIdAsync(id);

            if (existingTask == null)
            {
                return false; // Retorna false si no se encuentra
            }

            // Actualiza solo los campos necesarios desde el DTO
            existingTask.TaskName = entity.TaskName;
            existingTask.CategoryId = entity.CategoryId;

            // Llama al repositorio para guardar los cambios
            await _repository.UpdateAsync(existingTask);

            return true; // Retorna true si la actualización fue exitosa
        }



        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<TfaTask>> GetTasksByCategoryIdAsync(int categoryId)
        {
            return await _repository.GetTasksByCategoryIdAsync(categoryId);
        }
    }
}
