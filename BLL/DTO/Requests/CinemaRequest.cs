﻿using System.ComponentModel.DataAnnotations;

namespace BLL.DTO.Requests
{
    public class CinemaRequest
    {
        [Required(ErrorMessage = "Id cannot be null")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name cannot be null")]
        [StringLength(50, ErrorMessage = "Name length should be less than 50")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "Seance cannot be null")]
        public int SeanceId { get; set; }
    }
}
