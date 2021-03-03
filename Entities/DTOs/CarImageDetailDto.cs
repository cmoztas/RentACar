using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;

namespace Entities.DTOs
{
    public class CarImageDetailDto : IDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public IFormFile ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}