﻿namespace Application.Response
{
    public class TaskResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public Guid ProjectId { get; set; }
        public GenericResponse Status { get; set; }
        public UserResponse UserAssigned { get; set; }
    }
}
